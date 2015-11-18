using System;
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
                command.Parameters.AddWithValue("@Address", item.MemberAddress.Id);

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

            const string query = "SELECT * FROM Customer, Address WHERE Customer.Address_id=Address.id";

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
                        var theMember = new Member
                        {
                            Id = (int) reader["id"],
                            Fname = reader["fname"] == DBNull.Value ? string.Empty : (string) reader["fname"],
                            Minit = reader["minit"] == DBNull.Value ? string.Empty : (string) reader["minit"],
                            Lname = reader["lname"] == DBNull.Value ? string.Empty : (string) reader["lname"],
                            PhoneNumber = reader["phone"] == DBNull.Value
                                ? string.Empty
                                : (string) reader["phone"]
                        };

                        this.loadAddress(theMember, reader);

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

        private void loadAddress(Member theMember, MySqlDataReader reader)
        {
            theMember.MemberAddress.Id = reader["Address_id"] == DBNull.Value
                ? string.Empty
                : reader["Address_id"].ToString();
            theMember.MemberAddress.Street1 = reader["street1"] == DBNull.Value
                ? string.Empty
                : reader["street1"].ToString();
            theMember.MemberAddress.Street2 = reader["street2"] == DBNull.Value
                ? string.Empty
                : reader["street2"].ToString();
            theMember.MemberAddress.City = reader["city"] == DBNull.Value
                ? string.Empty
                : reader["city"].ToString();
            theMember.MemberAddress.State = reader["state"] == DBNull.Value
                ? string.Empty
                : reader["state"].ToString();
            theMember.MemberAddress.Zip = reader["zip"] == DBNull.Value
                ? string.Empty
                : reader["zip"].ToString();
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

            const string query = "SELECT * FROM Customer, Address WHERE (Customer.id LIKE @id or Customer.phone LIKE @id) AND Customer.Address_id=Address.id";

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
                        this.loadAddress(theMember, reader);
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

            const string query = "SELECT * FROM Customer, Address WHERE (Customer.fname LIKE @text OR Customer.lname LIKE @text OR CONCAT(Customer.fname,' ',Customer.lname) LIKE @text) AND Customer.Address_id=Address.id";

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
                        this.loadAddress(theMember, reader);
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