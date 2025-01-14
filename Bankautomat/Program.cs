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

            Datenbank datenbank = new Datenbank();

            // Prüfe ob die Datenbank existiert
            datenbank.CheckDatabaseFileExists();

            // Tabellen erstellen, falls noch nicht vorhanden
            datenbank.CreateTables();

            // Optional: Testdaten hinzufügen
            datenbank.AddCustomer("Winkler", "1234", 1000.00m);
            datenbank.AddCustomer("Rainer", "1234", 10000.00m);

            Application.Run(new Login());
        }
    }
}
