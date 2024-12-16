using System;
using System.Windows.Forms;

namespace Bankautomat
{
    public partial class Login : Form
    {
        private Datenbank datenbank;

        public Login()
        {
            InitializeComponent();
            datenbank = new Datenbank();
           
        }
        private void AnmeldeButton_Click(object sender, EventArgs e)
        {
            string benutzername = BenutzerNameBox.Text; // Benutzername vom Textfeld
            string passwort = PasswortBox.Text;         // Passwort vom Textfeld

            // Validieren des Logins mit der Datenbank
            if (datenbank.ValidateLogin(benutzername, passwort))
            {
                // Login erfolgreich
                MessageBox.Show("Login erfolgreich!");
                this.Hide();  // Login-Fenster verstecken
                Hauptmenue mainForm = new Hauptmenue(); // Neues Hauptmenü-Fenster öffnen
                mainForm.Show();
            }
            else
            {
                // Fehlgeschlagener Login
                MessageBox.Show("Ungültiger Benutzername oder Passwort.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
