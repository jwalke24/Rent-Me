using System.Data;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    /// <summary>
    /// This class is responsible for managing any generic SQL queries.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class GenericSqlController
    {
        private readonly IGenericSql theGenericSql;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSqlController"/> class.
        /// </summary>
        public GenericSqlController()
        {
            this.theGenericSql = new GenericSql();
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public DataSet ExecuteQuery(string query)
        {
          return this.theGenericSql.ExecuteQuery(query);  
        }
    }
}
