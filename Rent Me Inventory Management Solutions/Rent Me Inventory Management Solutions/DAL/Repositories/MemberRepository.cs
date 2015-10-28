using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using MySql.Data.MySqlClient;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class MemberRepository : IRepository<Member>
    {
        private readonly string CONNECTION_STRING;

        public MemberRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public void AddList(IList<Member> theList)
        {
            throw new NotImplementedException();
        }

        public void AddOne(Member item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            const string statement = "INSERT INTO Customer (fname, lname, minit, phone, AddressId)" +
                                        " VALUES (@Fname, @Lname, @Minit, @Phone, @Address)";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@Fname", item.Fname);
                command.Parameters.AddWithValue("@Lname", item.Lname);
                command.Parameters.AddWithValue("@Minit", item.Minit);
                command.Parameters.AddWithValue("@Phone", item.PhoneNumber);
                command.Parameters.AddWithValue("@Address", item.TheAddress);

                command.Connection = connection;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException mse)
                {

                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(Member item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
