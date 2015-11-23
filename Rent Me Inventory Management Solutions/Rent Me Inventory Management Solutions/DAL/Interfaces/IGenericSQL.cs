using System.Data;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Generic SQL repository.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IGenericSql
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        DataSet ExecuteQuery(string x);
    }
}
