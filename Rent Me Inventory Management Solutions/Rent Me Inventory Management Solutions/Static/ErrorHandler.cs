using System;
using System.IO;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.Static
{
    /// <summary>
    /// This class is responsible for handling and logging any errors encountered by the application.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal static class ErrorHandler
    {
        /// <summary>
        /// Displays the error message to user and log.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void DisplayErrorMessageToUserAndLog(string title, string message, Exception exception)
        {
            writeErrorToLogFile(title, message, exception);

            DisplayErrorBox(title, message);
        }

        /// <summary>
        /// Writes the error to log file.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        private static void writeErrorToLogFile(string title, string message, Exception exception)
        {
            using (var w = File.AppendText("RentMeLogs.txt"))
            {
                w.Write("\r\n");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", title.ToUpper());
                w.WriteLine("  :{0}", message);
                w.WriteLine("  :{0}", exception);
                w.WriteLine("-------------------------------");
            }
        }

        /// <summary>
        /// Displays the error box.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        public static void DisplayErrorBox(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}