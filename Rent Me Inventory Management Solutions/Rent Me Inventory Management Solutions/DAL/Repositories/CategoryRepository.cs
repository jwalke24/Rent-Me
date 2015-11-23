using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for querying Categories with the database.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class CategoryRepository : IRepository<Category>
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        public CategoryRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddOne(Category item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddList(IList<Category> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
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
                        category.Id = ((int) reader["id"]).ToString();
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

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">id is null or empty</exception>
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
                        category.Id = id;
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return category;
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
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(Category item)
        {
            throw new NotImplementedException();
        }
    }
}