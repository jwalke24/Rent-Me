using System;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View.Views;

namespace Rent_Me_Inventory_Management_Solutions
{
    /// <summary>
    /// This class is responsible for executing the application.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
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