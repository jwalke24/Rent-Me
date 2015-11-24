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
    class ReturnTransactionRepository : IRepository<ReturnTransaction>
    {
        private readonly string CONNECTION_STRING;
        public ReturnTransactionRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        public string AddOne(ReturnTransaction item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            string id = string.Empty;

            const string statement = "INSERT INTO ReturnTransaction (id, returnTime, Employee_id)" +
                                     " VALUES (@id, @time, @empid)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@id", item.id);
                command.Parameters.AddWithValue("@time", item.returnTime);
                command.Parameters.AddWithValue("@empid", item.Employee_id);

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

        public void AddList(IList<ReturnTransaction> theList)
        {
            throw new NotImplementedException();
        }

        public IList<ReturnTransaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReturnTransaction GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ReturnTransaction item)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(ReturnTransaction item)
        {
            throw new NotImplementedException();
        }
    }
}
