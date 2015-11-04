using System;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View;

namespace Rent_Me_Inventory_Management_Solutions
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainWindow());
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}