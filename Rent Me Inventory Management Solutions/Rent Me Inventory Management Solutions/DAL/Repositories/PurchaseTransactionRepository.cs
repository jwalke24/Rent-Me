using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for querying Purchase Transactions.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class PurchaseTransactionRepository : IPurchaseTransactionRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionRepository"/> class.
        /// </summary>
        public PurchaseTransactionRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string AddOne(PurchaseTransaction item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            var id = string.Empty;

            const string statement = "INSERT INTO PurchaseTransaction (transactionTime, Customer_id, Employee_id)" +
                                     " VALUES (@TransactionTime, @CustomerId, @EmployeeId)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@TransactionTime", item.TransactionTime);
                command.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("@EmployeeId", item.EmployeeId);

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

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddList(IList<PurchaseTransaction> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<PurchaseTransaction> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PurchaseTransaction GetById(string id)
        {
            const string query = "SELECT * " + 
                                 "FROM PurchaseTransaction " +
                                 "WHERE id = @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            var transaction = new PurchaseTransaction();

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        transaction.Id = ((int)reader["id"]).ToString();
                        transaction.TransactionTime = reader["transactionTime"] == DBNull.Value
                            ? DateTime.MinValue
                            : reader["transactionTime"] as DateTime? ?? DateTime.MinValue;
                        transaction.CustomerId = reader["Customer_id"] == DBNull.Value ? "0" : ((int) reader["Customer_id"]).ToString();
                        transaction.EmployeeId = reader["Employee_id"] == DBNull.Value ? "0" : ((int)reader["Employee_id"]).ToString();

                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return transaction;
        }

        /// <summary>
        /// Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
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

        /// <summary>
        /// Deletes the specified item from the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(PurchaseTransaction item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(PurchaseTransaction item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the transactions by customer identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<PurchaseTransaction> GetTransactionsByCustomerId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }


            var purchaseTransactions = new List<PurchaseTransaction>();

            const string query = "SELECT * FROM PurchaseTransaction WHERE Customer_id = @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var theTransaction = new PurchaseTransaction
                        {
                            Id = reader["id"].ToString(),
                            TransactionTime = reader["transactionTime"] as DateTime? ?? DateTime.MinValue,
                            CustomerId = reader["Customer_id"] == DBNull.Value ? "NULL" : reader["Customer_id"].ToString(),
                            EmployeeId = reader["Employee_id"] as string ?? string.Empty,
                        };


                        purchaseTransactions.Add(theTransaction);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return purchaseTransactions;
        }
    }
}
