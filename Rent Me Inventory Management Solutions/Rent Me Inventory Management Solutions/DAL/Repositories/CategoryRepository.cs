using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class CategoryRepository : IRepository<Category>
    {
        private readonly string CONNECTION_STRING;
        public CategoryRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }
        public void AddOne(Category item)
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<Category> theList)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            List<Category> furnitures = new List<Category>();

            const string query = "SELECT * FROM Category";

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
                        Category category = new Category();
                        category.ID = ((int)reader["id"]).ToString();
                        category.Name = reader["name"] == DBNull.Value ? String.Empty : (string)reader["name"];
                        category.Description = reader["description"] == DBNull.Value
                            ? String.Empty
                            : (string)reader["description"];

                        furnitures.Add(category);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }

                return furnitures;
            }
        }

        public Category GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
