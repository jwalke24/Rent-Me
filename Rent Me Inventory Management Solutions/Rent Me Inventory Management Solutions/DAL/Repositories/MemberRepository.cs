﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberRepository" /> class.
        /// </summary>
        public MemberRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public void AddList(IList<Member> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public string AddOne(Member item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            string id = string.Empty;

            const string statement = "INSERT INTO Customer (fname, lname, minit, phone, Address_id)" +
                                     " VALUES (@Fname, @Lname, @Minit, @Phone, @Address)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@Fname", item.Fname);
                command.Parameters.AddWithValue("@Lname", item.Lname);
                command.Parameters.AddWithValue("@Minit", item.Minit);
                command.Parameters.AddWithValue("@Phone", item.PhoneNumber);
                command.Parameters.AddWithValue("@Address", item.AddressId);

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

        public void Delete(Member item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(Member item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteById(string id)
        {
            var sqlStatement = "DELETE FROM Customer WHERE id = @id";

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
        ///     Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Member> GetAll()
        {
            var members = new List<Member>();

            const string query = "SELECT * FROM Customer";

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
                        var theMember = new Member();
                        theMember.Id = (int) reader["id"];
                        theMember.Fname = reader["fname"] == DBNull.Value ? string.Empty : (string) reader["fname"];
                        theMember.Minit = reader["minit"] == DBNull.Value ? string.Empty : (string) reader["minit"];
                        theMember.Lname = reader["lname"] == DBNull.Value ? string.Empty : (string) reader["lname"];
                        theMember.PhoneNumber = reader["phone"] == DBNull.Value
                            ? string.Empty
                            : (string) reader["phone"];
                        theMember.AddressId = reader["Address_id"] == DBNull.Value
                            ? string.Empty
                            : ((int) reader["Address_id"]).ToString();
                        members.Add(theMember);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return members;
        }

        public Member GetById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the database by identifier or phone.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Member> SearchByIDOrPhone(string id)
        {
            var members = new List<Member>();

            const string query = "SELECT * FROM Customer WHERE id LIKE @id or phone LIKE @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", id + "%");

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var theMember = new Member();
                        theMember.Id = (int)reader["id"];
                        theMember.Fname = reader["fname"] == DBNull.Value ? string.Empty : (string)reader["fname"];
                        theMember.Minit = reader["minit"] == DBNull.Value ? string.Empty : (string)reader["minit"];
                        theMember.Lname = reader["lname"] == DBNull.Value ? string.Empty : (string)reader["lname"];
                        theMember.PhoneNumber = reader["phone"] == DBNull.Value
                            ? string.Empty
                            : (string)reader["phone"];
                        theMember.AddressId = reader["Address_id"] == DBNull.Value
                            ? string.Empty
                            : ((int)reader["Address_id"]).ToString();
                        members.Add(theMember);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return members;
        }

        /// <summary>
        /// Searches the database by name for a customer.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public IList<Member> SearchByName(string text)
        {
            var members = new List<Member>();

            const string query = "SELECT * FROM Customer WHERE fname LIKE @text OR lname LIKE @text OR CONCAT(fname,' ',lname) LIKE @text";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;
                command.Parameters.AddWithValue("@text", text + "%");
                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var theMember = new Member();
                        theMember.Id = (int)reader["id"];
                        theMember.Fname = reader["fname"] == DBNull.Value ? string.Empty : (string)reader["fname"];
                        theMember.Minit = reader["minit"] == DBNull.Value ? string.Empty : (string)reader["minit"];
                        theMember.Lname = reader["lname"] == DBNull.Value ? string.Empty : (string)reader["lname"];
                        theMember.PhoneNumber = reader["phone"] == DBNull.Value
                            ? string.Empty
                            : (string)reader["phone"];
                        theMember.AddressId = reader["Address_id"] == DBNull.Value
                            ? string.Empty
                            : ((int)reader["Address_id"]).ToString();
                        members.Add(theMember);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return members;
        }
    }
}