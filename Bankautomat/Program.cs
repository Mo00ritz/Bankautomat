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
            // datenbank.ResetDatabase();
            datenbank.CreateTables();

            // Optional: Testdaten hinzufügen
            datenbank.AddCustomer("1001", "1234", 1000.00m, "Winkler", "Rainer", "0123456789");
            datenbank.AddCustomer("1002", "1234", 10000.00m, "Lester", "Moe", "9876543210");

            Application.Run(new Login());
        }
    }
}
