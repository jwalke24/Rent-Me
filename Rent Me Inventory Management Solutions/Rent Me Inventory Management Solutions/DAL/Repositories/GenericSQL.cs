using System.Data;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for handling generic SQL queries.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    internal class GenericSql : IGenericSql
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSql"/> class.
        /// </summary>
        public GenericSql()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public DataSet ExecuteQuery(string x)
        {
            DataSet objDataSet = new DataSet();
            var objConn = new MySqlConnection(this.CONNECTION_STRING);

            var objComm = new MySqlCommand(x);

            objComm.Connection = objConn;

            MySqlDataAdapter objDataAdapter = new MySqlDataAdapter(objComm);

            try
            {
                if (objConn.State == ConnectionState.Closed)
                {
                    objConn.Open();
                }

                objDataAdapter.Fill(objDataSet);
            }
            finally
            {
                objConn.Close();
            }

            

            return objDataSet;
        }
    }
}
