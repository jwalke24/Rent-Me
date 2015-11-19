using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class GenericSQL : IGenericSQL
    {
        private readonly string CONNECTION_STRING;

        public GenericSQL()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }



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
