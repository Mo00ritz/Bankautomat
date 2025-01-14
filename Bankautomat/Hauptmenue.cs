using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Bankautomat
{
    public partial class Hauptmenue : Form
    {
        private string kontoNummer;
        private Datenbank datenbank;

        public Hauptmenue(string kontoNummer)
        {
            InitializeComponent();
            this.kontoNummer = kontoNummer;
            datenbank = new Datenbank();
            LadeBenutzerdaten();
        }

        private void LadeBenutzerdaten()
        {
            try
            {
                using (var connection = datenbank.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT Kontostand 
                        FROM Kunden 
                        WHERE AccountNummer = @kontoNummer;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                        var kontostand = command.ExecuteScalar();

                        if (kontostand != null)
                        {
                            Kundennummerlbl.Text = kontoNummer;
                            Kontostandlbl.Text = $"{kontostand} €";
                        }
                        else
                        {
                            MessageBox.Show("Fehler: Kontodaten konnten nicht geladen werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    LadeTransaktionen(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LadeTransaktionen(SQLiteConnection connection)
        {
            try
            {
                string query = @"
                    SELECT Datum, Menge, TransaktionsTyp 
                    FROM Transaktionen 
                    WHERE KundenId = (SELECT Id FROM Kunden WHERE AccountNummer = @kontoNummer)
                    ORDER BY Datum DESC;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                    using (var reader = command.ExecuteReader())
                    {
                        TransaktionenListBox.Items.Clear();

                        while (reader.Read())
                        {
                            string datum = reader["Datum"].ToString();
                            string menge = reader["Menge"].ToString();
                            string typ = reader["TransaktionsTyp"].ToString();

                            TransaktionenListBox.Items.Add($"{datum}: {typ} {menge} €");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Transaktionen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Methode für den Logout-Button
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sie werden ausgeloggt.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        // Methode für den Überweisungs-Button
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            string zielKonto = Microsoft.VisualBasic.Interaction.InputBox("Geben Sie die Ziel-Kontonummer ein:", "Überweisung");
            string betragInput = Microsoft.VisualBasic.Interaction.InputBox("Geben Sie den Überweisungsbetrag ein:", "Überweisung");

            if (decimal.TryParse(betragInput, out decimal betrag) && betrag > 0)
            {
                try
                {
                    using (var connection = datenbank.GetConnection())
                    {
                        connection.Open();

                        // Überprüfen, ob Zielkonto existiert
                        string checkZielkontoQuery = "SELECT COUNT(1) FROM Kunden WHERE AccountNummer = @zielKonto;";
                        using (var checkCommand = new SQLiteCommand(checkZielkontoQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@zielKonto", zielKonto);
                            int zielkontoExists = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (zielkontoExists == 0)
                            {
                                MessageBox.Show("Das Zielkonto existiert nicht.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Transaktionen und Kontostandsaktualisierungen
                        using (var transaction = connection.BeginTransaction())
                        {
                            // Absender-Kontostand aktualisieren
                            string updateAbsenderQuery = @"
                        UPDATE Kunden 
                        SET Kontostand = Kontostand - @betrag 
                        WHERE AccountNummer = @kontoNummer;";

                            using (var command = new SQLiteCommand(updateAbsenderQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@betrag", betrag);
                                command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                                command.ExecuteNonQuery();
                            }

                            // Empfänger-Kontostand aktualisieren
                            string updateEmpfaengerQuery = @"
                        UPDATE Kunden 
                        SET Kontostand = Kontostand + @betrag 
                        WHERE AccountNummer = @zielKonto;";

                            using (var command = new SQLiteCommand(updateEmpfaengerQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@betrag", betrag);
                                command.Parameters.AddWithValue("@zielKonto", zielKonto);
                                command.ExecuteNonQuery();
                            }

                            // Transaktion für Absender hinzufügen
                            string insertAbsenderTransaction = @"
                        INSERT INTO Transaktionen (KundenId, Datum, Menge, TransaktionsTyp)
                        VALUES (
                            (SELECT Id FROM Kunden WHERE AccountNummer = @kontoNummer),
                            @datum,
                            @betrag,
                            'Überweisung - Absender');";

                            using (var command = new SQLiteCommand(insertAbsenderTransaction, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                                command.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                command.Parameters.AddWithValue("@betrag", -betrag);
                                command.ExecuteNonQuery();
                            }

                            // Transaktion für Empfänger hinzufügen
                            string insertEmpfaengerTransaction = @"
                        INSERT INTO Transaktionen (KundenId, Datum, Menge, TransaktionsTyp)
                        VALUES (
                            (SELECT Id FROM Kunden WHERE AccountNummer = @zielKonto),
                            @datum,
                            @betrag,
                            'Überweisung - Empfänger');";

                            using (var command = new SQLiteCommand(insertEmpfaengerTransaction, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@zielKonto", zielKonto);
                                command.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                command.Parameters.AddWithValue("@betrag", betrag);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }

                        MessageBox.Show("Überweisung erfolgreich durchgeführt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LadeBenutzerdaten(); // Aktualisiert die Oberfläche
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Überweisung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ungültiger Betrag.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Methode für den Aktualisieren-Button
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            LadeBenutzerdaten();
            MessageBox.Show("Daten aktualisiert.", "Aktualisieren", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void depositBtn_Click(object sender, EventArgs e)
        {
            string betragInput = Microsoft.VisualBasic.Interaction.InputBox(
                "Geben Sie den Betrag ein, den Sie einzahlen möchten:",
                "Einzahlung"
            );

            if (decimal.TryParse(betragInput, out decimal betrag) && betrag > 0)
            {
                try
                {
                    using (var connection = datenbank.GetConnection())
                    {
                        connection.Open();

                        // Kontostand aktualisieren
                        string updateQuery = @"
                    UPDATE Kunden
                    SET Kontostand = Kontostand + @betrag
                    WHERE AccountNummer = @kontoNummer;";

                        using (var command = new SQLiteCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@betrag", betrag);
                            command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                            command.ExecuteNonQuery();
                        }

                        // Transaktion hinzufügen
                        string insertTransactionQuery = @"
                    INSERT INTO Transaktionen (KundenId, Datum, Menge, TransaktionsTyp)
                    VALUES (
                        (SELECT Id FROM Kunden WHERE AccountNummer = @kontoNummer),
                        @datum,
                        @betrag,
                        'Einzahlung');";

                        using (var command = new SQLiteCommand(insertTransactionQuery, connection))
                        {
                            command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                            command.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@betrag", betrag);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Einzahlung von {betrag:C} erfolgreich durchgeführt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LadeBenutzerdaten(); // Aktualisiere die Benutzeroberfläche
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Einzahlung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Betrag ein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            // Eingabeaufforderung für den Abhebungsbetrag
            string betragInput = Microsoft.VisualBasic.Interaction.InputBox("Geben Sie den Abhebungsbetrag ein:", "Abheben");

            if (decimal.TryParse(betragInput, out decimal abhebungsbetrag) && abhebungsbetrag > 0)
            {
                try
                {
                    using (var connection = datenbank.GetConnection())
                    {
                        connection.Open();

                        // Überprüfen, ob der Kontostand ausreicht
                        string checkBalanceQuery = "SELECT Kontostand FROM Kunden WHERE AccountNummer = @kontoNummer;";
                        using (var command = new SQLiteCommand(checkBalanceQuery, connection))
                        {
                            command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                            object result = command.ExecuteScalar();

                            if (result != null && decimal.TryParse(result.ToString(), out decimal kontostand))
                            {
                                if (kontostand >= abhebungsbetrag)
                                {
                                    // Kontostand aktualisieren
                                    string updateQuery = @"
                                UPDATE Kunden
                                SET Kontostand = Kontostand - @betrag
                                WHERE AccountNummer = @kontoNummer;";

                                    using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@betrag", abhebungsbetrag);
                                        updateCommand.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                                        updateCommand.ExecuteNonQuery();
                                    }

                                    // Transaktion speichern
                                    datenbank.AddTransaction(kontoNummer, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), abhebungsbetrag, "Abhebung");

                                    // Benutzeroberfläche aktualisieren
                                    LadeBenutzerdaten();
                                    MessageBox.Show($"Abhebung von {abhebungsbetrag:C} erfolgreich durchgeführt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Unzureichender Kontostand für diese Transaktion.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Fehler: Konto nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler bei der Abhebung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ungültiger Betrag. Bitte geben Sie einen positiven Wert ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
