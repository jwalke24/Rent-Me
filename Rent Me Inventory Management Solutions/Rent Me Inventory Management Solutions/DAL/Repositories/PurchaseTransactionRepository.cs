using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class PurchaseTransactionRepository : IPurchaseTransactionRepository
    {
        private readonly string CONNECTION_STRING;

        public PurchaseTransactionRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public string AddOne(PurchaseTransaction item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            string id = string.Empty;

            const string statement = "INSERT INTO PurchaseTransaction (transactionTime, Customer_id, Employee_id)" +
                                     " VALUES (@TransactionTime, @CustomerID, @EmployeeID)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@TransactionTime", item.TransactionTime);
                command.Parameters.AddWithValue("@CustomerID", item.CustomerID);
                command.Parameters.AddWithValue("@EmployeeID", item.EmployeeID);

                command.Connection = connection;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    id = command.LastInsertedId.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return id;
        }

        public void AddList(IList<PurchaseTransaction> theList)
        {
            throw new NotImplementedException();
        }

        public IList<PurchaseTransaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseTransaction GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            var sqlStatement = "DELETE FROM PurchaseTransaction WHERE id = @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            var command = new MySqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@id", id);

            command.Connection = connection;

            try
            {
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public void Delete(PurchaseTransaction item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(PurchaseTransaction item)
        {
            throw new NotImplementedException();
        }
    }
}
