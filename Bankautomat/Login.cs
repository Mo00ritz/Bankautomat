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
                MessageBox.Show("Login erfolgreich!");
                Hauptmenue hauptmenue = new Hauptmenue(benutzername);
                this.Hide();
                hauptmenue.Show();
            }
            else
            {
                // Fehlgeschlagener Login
                MessageBox.Show("Ungültiger Benutzername oder Passwort.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
