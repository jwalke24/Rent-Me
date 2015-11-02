using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.DAL
{
    class DBConnection
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
    }
}
