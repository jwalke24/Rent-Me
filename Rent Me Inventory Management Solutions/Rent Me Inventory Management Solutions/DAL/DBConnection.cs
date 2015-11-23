using System.Configuration;

namespace Rent_Me_Inventory_Management_Solutions.DAL
{
    /// <summary>
    /// This class is responsible for retrieving the database connection string.
    /// </summary>
    /// <author>Jonathan Walker and Jonah Nestrick</author>
    /// <version>Fall 2015</version>
    internal class DbConnection
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