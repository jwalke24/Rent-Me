using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This calss is responsible for querying Styles.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class StyleRepository : IRepository<Style>
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleRepository"/> class.
        /// </summary>
        public StyleRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddOne(Style item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddList(IList<Style> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Style> GetAll()
        {
            var styles = new List<Style>();

            const string query = "SELECT * FROM Style";

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
                        var style = new Style();
                        style.Id = ((int) reader["id"]).ToString();
                        style.Name = reader["name"] == DBNull.Value ? string.Empty : (string) reader["name"];
                        style.Description = reader["description"] == DBNull.Value
                            ? string.Empty
                            : (string) reader["description"];

                        styles.Add(style);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }

                return styles;
            }
        }

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">id is null or empty</exception>
        public Style GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is null or empty");
            }

            var style = new Style();
            const string query = "SELECT * FROM Style WHERE id=@Id";

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
                        style.Name = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
                        style.Description = reader["description"] == DBNull.Value
                            ? string.Empty
                            : reader["description"].ToString();
                        style.Id = id;
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return style;
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
        public void Delete(Style item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(Style item)
        {
            throw new NotImplementedException();
        }
    }
}