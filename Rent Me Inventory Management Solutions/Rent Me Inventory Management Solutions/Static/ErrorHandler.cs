using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions
{
    static class ErrorHandler
    {
        public static void DisplayErrorMessageToUserAndLog(string title, string message, Exception exception)
        {
            writeErrorToLogFile(title, message, exception);

            displayErrorBox(title, message);
        }

        private static void writeErrorToLogFile(string title, string message, Exception exception)
        {
            using (StreamWriter w = File.AppendText("RentMeLogs.txt"))
            {
                w.Write("\r\n");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", title.ToUpper());
                w.WriteLine("  :{0}", message);
                w.WriteLine("  :{0}", exception.ToString());
                w.WriteLine("-------------------------------");
            }
        }

        public static void displayErrorBox(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
