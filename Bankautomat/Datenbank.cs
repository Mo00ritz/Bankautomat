using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace Bankautomat
{
    public class Datenbank
    {
        // Verbindung zur SQLite-Datenbank
        private string connectionString = @"Data Source=C:\Users\morit\Desktop\Bankautomat\Bankautomat\BankDB.db;Version=3;";

        // Gibt die Verbindung zur Datenbank zurück
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // Erstellen der Tabellen bei Bedarf
        public void CreateTables()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string createKundenTabelle = @"
        CREATE TABLE IF NOT EXISTS Kunden (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            AccountNummer TEXT NOT NULL,
            PIN TEXT NOT NULL,
            Kontostand REAL NOT NULL
        );";

                string createTransaktionsTabelle = @"
        CREATE TABLE IF NOT EXISTS Transaktionen (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            KundenId INTEGER NOT NULL,
            Datum TEXT NOT NULL,
            Menge REAL NOT NULL,
            TransaktionsTyp TEXT NOT NULL,
            FOREIGN KEY (KundenId) REFERENCES Kunden(Id)
        );";

                using (var command = new SQLiteCommand(createKundenTabelle, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createTransaktionsTabelle, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Kunden hinzufügen
        public void AddCustomer(string kontoNummer, string pin, decimal kontostand)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string hashedPin = ComputeSHA256Hash(pin);

                        string query = @"
                    INSERT INTO Kunden (AccountNummer, PIN, Kontostand)
                    VALUES (@kontoNummer, @hashedPin, @kontostand);";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                            command.Parameters.AddWithValue("@hashedPin", hashedPin);
                            command.Parameters.AddWithValue("@kontostand", kontostand);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Speichert die Transaktion
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Rollback bei Fehler
                        Console.WriteLine("Fehler beim Einfügen: " + ex.Message);
                    }
                }
            }
        }

        // Kunden aus der Datenbank abrufen
        public void GetCustomers()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM Kunden;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Konto: {reader["AccountNummer"]}, Kontostand: {reader["Kontostand"]}");
                    }
                }
            }
        }

        // Kontostand aktualisieren
        public void UpdateBalance(string kontoNummer, decimal neuerKontostand)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"
                UPDATE Kunden
                SET Kontostand = @neuerKontostand
                WHERE AccountNummer = @kontoNummer;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@neuerKontostand", neuerKontostand);
                    command.Parameters.AddWithValue("@kontoNummer", kontoNummer);

                    command.ExecuteNonQuery();
                }
            }
        }

        //Geld Abheben
        public void AddTransaction(string kontoNummer, string datum, decimal betrag, string typ)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
        INSERT INTO Transaktionen (KundenId, Datum, Menge, TransaktionsTyp)
        VALUES ((SELECT Id FROM Kunden WHERE AccountNummer = @kontoNummer), @datum, @betrag, @typ);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                    command.Parameters.AddWithValue("@datum", datum);
                    command.Parameters.AddWithValue("@betrag", betrag);
                    command.Parameters.AddWithValue("@typ", typ);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Kunden löschen
        public void DeleteCustomer(string kontoNummer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "DELETE FROM Kunden WHERE AccountNummer = @kontoNummer;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kontoNummer", kontoNummer);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Login-Validierung
        public bool ValidateLogin(string benutzername, string passwort)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT PIN FROM Kunden WHERE AccountNummer = @benutzername;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@benutzername", benutzername);

                    var storedPasswordHash = command.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(storedPasswordHash))
                    {
                        // Passwörter mit SHA256 hashen und vergleichen
                        using (SHA256 sha256Hash = SHA256.Create())
                        {
                            var computedHash = ComputeSHA256Hash(passwort);

                            return storedPasswordHash == computedHash; // Vergleiche die Hashes
                        }
                    }
                }
            }
            return false; // Wenn Benutzername oder Passwort falsch sind
        }

        // Helper-Methoden zum Hashen des Passworts mit SHA256
        private static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void CheckDatabaseFileExists()
        {
            string dbFilePath = Path.Combine(Directory.GetCurrentDirectory(), "BankDB.db");

            if (File.Exists(dbFilePath))
            {
                Console.WriteLine("Die BankDB.db Datei existiert.");
            }
            else
            {
                Console.WriteLine("Die BankDB.db Datei fehlt.");
            }
        }
    }
}
