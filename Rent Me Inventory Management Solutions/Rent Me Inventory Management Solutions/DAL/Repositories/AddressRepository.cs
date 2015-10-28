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

        public AddressRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public void AddList(IList<Address> theList)
        {
            throw new NotImplementedException();
        }

        public void AddOne(Address item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

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
                        anAddress.Street1 = reader["street1"] == DBNull.Value ? String.Empty : (string)reader["street1"];
                        anAddress.Street2 = reader["street2"] == DBNull.Value ? String.Empty : (string)reader["street2"];
                        anAddress.City = reader["city"] == DBNull.Value ? String.Empty : (string)reader["city"];
                        anAddress.State = reader["state"] == DBNull.Value ? String.Empty : (string)reader["state"];
                        anAddress.Zip = reader["zip"] == DBNull.Value ? String.Empty : (string)reader["zip"];
                        addresses.Add(anAddress);
                    }
                }
                catch (MySqlException mse)
                {

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
