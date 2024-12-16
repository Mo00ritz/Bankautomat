using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankautomat
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            Datenbank datenbank = new Datenbank();

            // Prüfe ob die Datenbank existiert
            datenbank.CheckDatabaseFileExists();

            // Tabellen erstellen, falls noch nicht vorhanden
            datenbank.CreateTables();

            // Kunden hinzufügen
            datenbank.AddCustomer("123456", "1234", 1000.00m);

            // Kunden abrufen
            datenbank.GetCustomers();

            // Kontostand aktualisieren
            datenbank.UpdateBalance("123456", 1500.00m);

            // Kunden nach Update abrufen
            datenbank.GetCustomers();

            // Kunden löschen
            datenbank.DeleteCustomer("123456");

            // Kunden nach Löschung abrufen
            datenbank.GetCustomers();
        }
    }
}
