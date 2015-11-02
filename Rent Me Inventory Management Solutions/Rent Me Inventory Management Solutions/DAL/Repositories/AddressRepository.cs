using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class AddressRepository : IRepository<Address>
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
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
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddOne(Address item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            const string statement = "INSERT INTO Address (street1, street2, city, state, zip)" +
                                        " VALUES (@street1, @street2, @city, @state, @zip)";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(statement))
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
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(Address item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();

            const string query = "SELECT * FROM Address";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Address anAddress = new Address();
                        anAddress.Id = (int)reader["id"];
                        anAddress.Street1 = reader["street1"] == DBNull.Value ? String.Empty : (string)reader["street1"];
                        anAddress.Street2 = reader["street2"] == DBNull.Value ? String.Empty : (string)reader["street2"];
                        anAddress.City = reader["city"] == DBNull.Value ? String.Empty : (string)reader["city"];
                        anAddress.State = reader["state"] == DBNull.Value ? String.Empty : (string)reader["state"];
                        anAddress.Zip = reader["zip"] == DBNull.Value ? String.Empty : (string)reader["zip"];
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
            throw new NotImplementedException();
        }
    }
}
