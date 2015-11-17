﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class AddressRepository : IRepository<Address>
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddressRepository" /> class.
        /// </summary>
        public AddressRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public void AddList(IList<Address> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public string AddOne(Address item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            string id = string.Empty;

            const string statement = "INSERT INTO Address (street1, street2, city, state, zip)" +
                                     " VALUES (@street1, @street2, @city, @state, @zip)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@street1", item.Street1);
                command.Parameters.AddWithValue("@street2", item.Street2);
                command.Parameters.AddWithValue("@city", item.City);
                command.Parameters.AddWithValue("@state", item.State);
                command.Parameters.AddWithValue("@zip", item.Zip);

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

        public void Delete(Address item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(Address item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Address> GetAll()
        {
            var addresses = new List<Address>();

            const string query = "SELECT * FROM Address";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var anAddress = new Address();
                        anAddress.Id = reader["id"].ToString();
                        anAddress.Street1 = reader["street1"] == DBNull.Value
                            ? string.Empty
                            : (string) reader["street1"];
                        anAddress.Street2 = reader["street2"] == DBNull.Value
                            ? string.Empty
                            : (string) reader["street2"];
                        anAddress.City = reader["city"] == DBNull.Value ? string.Empty : (string) reader["city"];
                        anAddress.State = reader["state"] == DBNull.Value ? string.Empty : (string) reader["state"];
                        anAddress.Zip = reader["zip"] == DBNull.Value ? string.Empty : (string) reader["zip"];
                        addresses.Add(anAddress);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return addresses;
        }

        public Address GetById(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is null or empty");
            }

            var address = new Address();

            const string query = "SELECT * FROM Address WHERE id=@Id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        address.Street1 = reader["street1"] == DBNull.Value
                            ? String.Empty
                            : reader["street1"].ToString();
                        address.Street2 = reader["street2"] == DBNull.Value
                            ? String.Empty
                            : reader["street2"].ToString();
                        address.City = reader["city"] == DBNull.Value ? String.Empty : reader["city"].ToString();
                        address.State = reader["state"] == DBNull.Value ? String.Empty : reader["state"].ToString();
                        address.Zip = reader["zip"] == DBNull.Value ? String.Empty : reader["zip"].ToString();
                        address.Id = id;
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return address;
        }
    }
}