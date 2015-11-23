﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for querying Purchase Transaction Items.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class PurchaseTransactionItemRepository : IPurchaseTransactionItemRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTransactionItemRepository"/> class.
        /// </summary>
        public PurchaseTransactionItemRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddOne(PurchaseTransaction_Item item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddList(IList<PurchaseTransaction_Item> theList)
        {
            if (theList == null)
            {
                throw new ArgumentNullException();
            }

            const string statement =
                "INSERT INTO PurchaseTransaction_Item (leaseTime, quantity, Furniture_id, PurchaseTransaction_id)" +
                " VALUES (@LeaseTime, @Quantity, @FurnitureId, @PurchaseTransactionId)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Connection = connection;

                try
                {
                    command.Parameters.Add("@LeaseTime", MySqlDbType.Int32);
                    command.Parameters.Add("@Quantity", MySqlDbType.Int32);
                    command.Parameters.Add("@FurnitureId", MySqlDbType.Int32);
                    command.Parameters.Add("@PurchaseTransactionId", MySqlDbType.Int32);

                    command.Connection.Open();

                    foreach (var item in theList)
                    {
                        command.Parameters["@LeaseTime"].Value = item.LeaseTime;
                        command.Parameters["@Quantity"].Value = item.Quantity;
                        command.Parameters["@FurnitureId"].Value = int.Parse(item.FurnitureId);
                        command.Parameters["@PurchaseTransactionId"].Value = int.Parse(item.PurchaseTransactionId);
                        command.ExecuteNonQuery();
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<PurchaseTransaction_Item> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PurchaseTransaction_Item GetById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified item from the database.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Delete(PurchaseTransaction_Item item)
        {
            var sqlStatement = "DELETE FROM PurchaseTransaction_Item WHERE Furniture_id = @id AND leaseTime = @lease AND quantity = @quantity AND PurchaseTransaction_id = @pid";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            var command = new MySqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@id", item.FurnitureId);
            command.Parameters.AddWithValue("@lease", item.LeaseTime);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            command.Parameters.AddWithValue("@pid", item.PurchaseTransactionId);

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
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(PurchaseTransaction_Item item)
        {
            throw new NotImplementedException();
        }
    }
}
