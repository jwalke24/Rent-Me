using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Network
{
    class SqlNetwork
    {
        private static readonly String CONNECTION_STRING = "server=160.10.23.6; port=3306; uid=cs3230f15a;" +
             "pwd=aQPrVq2yP6nc6Ury;database=cs3230f15a;";

        public LoginSession loginEmployeeToDatabase(LoginSession theSession)
        {
            string sqlStatement = "SELECT id FROM Employee WHERE id = @Username AND password = @Password";

            if (theSession == null)
            {
                throw new NullReferenceException();
            }

            MySqlConnection conn = new MySqlConnection(SqlNetwork.CONNECTION_STRING);

            MySqlCommand cmd = new MySqlCommand(sqlStatement);

            cmd.Parameters.AddWithValue("@Username", theSession.Id);
            cmd.Parameters.AddWithValue("@Password", theSession.Password);

            cmd.Connection = conn;

            try
            {
                cmd.Connection.Open();
                var empID = cmd.ExecuteScalar();

                if (empID == null || ((int) empID) != theSession.Id)
                {
                    theSession.isAuthenticated = false;
                }
                else
                {
                    theSession.isAuthenticated = true;
                }
            }
            catch (Exception e)
            {
                theSession.isAuthenticated = false;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return theSession;
        }


    }
}
