using System.Configuration;

namespace Rent_Me_Inventory_Management_Solutions.DAL
{
    internal class DBConnection
    {
        /// <summary>
        ///     Gets the connection string.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
    }
}