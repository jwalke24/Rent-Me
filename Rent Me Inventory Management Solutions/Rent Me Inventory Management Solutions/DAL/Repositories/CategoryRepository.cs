using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class CategoryRepository : IRepository<Category>
    {
        private readonly string CONNECTION_STRING;

        public CategoryRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public string AddOne(Category item)
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<Category> theList)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            var categories = new List<Category>();

            const string query = "SELECT * FROM Category";

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
                        var category = new Category();
                        category.ID = ((int) reader["id"]).ToString();
                        category.Name = reader["name"] == DBNull.Value ? string.Empty : (string) reader["name"];
                        category.Description = reader["description"] == DBNull.Value
                            ? string.Empty
                            : (string) reader["description"];

                        categories.Add(category);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }

                return categories;
            }
        }

        public Category GetById(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is null or empty");   
            }

            var category = new Category();
            const string query = "SELECT * FROM Category WHERE id=@Id";

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
                        category.Name = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
                        category.Description = reader["description"] == DBNull.Value
                            ? string.Empty
                            : reader["description"].ToString();
                        category.ID = id;
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return category;
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(Category item)
        {
            throw new NotImplementedException();
        }
    }
}