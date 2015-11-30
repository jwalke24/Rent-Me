using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for querying Furniture with the database.
    /// </summary>
    /// <author>Jonathan Walker and Jonah Nestrick</author>
    /// <version>Fall 2015</version>
    internal class FurnitureRepository : IFurnitureRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FurnitureRepository" /> class.
        /// </summary>
        public FurnitureRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">@Item is null</exception>
        public string AddOne(Furniture item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"Item is null");
            }

            string id = string.Empty;

            const string statement =
                "INSERT INTO Furniture (quantity, name, description, price, lateFee, Category_id, Style_id)" +
                " VALUES (@quantity, @name, @description, @price, @late, @cat, @style)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@quantity", item.Quantity);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@description", item.Description);
                command.Parameters.AddWithValue("@price", item.Price);
                command.Parameters.AddWithValue("@late", item.LateFee);
                command.Parameters.AddWithValue("@cat", item.CategoryId);
                command.Parameters.AddWithValue("@style", item.StyleId);


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

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddList(IList<Furniture> theList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Furniture> GetAll()
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT Furniture.*, " +
                                 "Category.name AS CategoryName, Style.name AS StyleName " +
                                 "FROM Furniture, Category, Style " +
                                 "WHERE Furniture.Category_id = Category.id AND Furniture.Style_id = Style.id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    this.furnitureLoader(reader, furnitures);
                }
                finally
                {
                    command.Connection.Close();
                }

                return furnitures;
            }
        }

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Furniture GetById(string id)
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT Furniture.*, " +
                                 "Category.name AS CategoryName, Style.name AS StyleName " +
                                 "FROM Furniture, Category, Style " +
                                 "WHERE Furniture.id = @id AND Furniture.Category_id = Category.id AND Furniture.Style_id = Style.id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@id", id);
                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    this.furnitureLoader(reader, furnitures);
                }
                finally
                {
                    command.Connection.Close();
                }

                if (furnitures.Count == 0)
                {
                    return null;
                }
                else
                {
                    return furnitures[0];
                }
            }
        }

        /// <summary>
        /// Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteById(string id)
        {
            var sqlStatement = "DELETE FROM Furniture WHERE id = @id";

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
        /// Deletes the specified item from the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(Furniture item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(Furniture item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"Item is null");
            }

            const string statement =
                "UPDATE Furniture " +
                "SET quantity = @quantity, name = @name, description = @description, price = @price, lateFee = @late, Category_id = @cat, Style_id = @style" +
                " WHERE id = @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@quantity", item.Quantity);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@description", item.Description);
                command.Parameters.AddWithValue("@price", item.Price);
                command.Parameters.AddWithValue("@late", item.LateFee);
                command.Parameters.AddWithValue("@cat", item.CategoryId);
                command.Parameters.AddWithValue("@style", item.StyleId);
                command.Parameters.AddWithValue("@id", item.Id);


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

        private void furnitureLoader(MySqlDataReader reader, List<Furniture> furnitures)
        {
            while (reader.Read())
            {
                var furniture = new Furniture();
                furniture.Id = ((int)reader["id"]).ToString();
                furniture.Quantity = reader["quantity"] as uint? ?? uint.MinValue;
                furniture.Name = reader["name"] == DBNull.Value ? string.Empty : (string)reader["name"];
                furniture.Description = reader["description"] == DBNull.Value
                    ? string.Empty
                    : (string)reader["description"];
                furniture.Price = reader["price"] as decimal? ?? decimal.Zero;
                furniture.LateFee = reader["lateFee"] as decimal? ?? decimal.Zero;
                furniture.CategoryId = (reader["Category_id"] as int? ?? int.MinValue).ToString();
                furniture.StyleId = (reader["Style_id"] as int? ?? int.MinValue).ToString();
                furniture.CategoryName = reader["CategoryName"] == DBNull.Value ? string.Empty : reader["CategoryName"].ToString();
                furniture.StyleName = reader["StyleName"] == DBNull.Value ? string.Empty : reader["StyleName"].ToString();

                furnitures.Add(furniture);
            }
        }

        /// <summary>
        /// Gets all by identifier prefix.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Furniture> GetAllByIdPrefix(int id)
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT Furniture.*, Category.name AS CategoryName, Style.name AS StyleName " +
                "FROM Furniture, Category, Style " +
                "WHERE Furniture.Category_id = Category.id AND Furniture.Style_id = Style.id AND Furniture.id LIKE @id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@id", id + "%");
                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    this.furnitureLoader(reader, furnitures);
                }
                finally
                {
                    command.Connection.Close();
                }

                return furnitures;
            }
        }

        /// <summary>
        /// Gets all by category style criteria.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="style">The style.</param>
        /// <returns></returns>
        public IList<Furniture> GetAllByCategoryStyleCriteria(Category category, Style style)
        {
            var furnitures = new List<Furniture>();

            const string query =
                "SELECT Furniture.*, " +
                "Category.name AS CategoryName, Style.name AS StyleName " +
                "FROM Furniture, Category, Style " +
                "WHERE (Furniture.Category_id LIKE @cat AND Furniture.Style_id LIKE @style) AND Furniture.Category_id = Category.id AND Furniture.Style_id = Style.id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@cat", category?.Id ?? "%");
                command.Parameters.AddWithValue("@style", style?.Id ?? "%");
                try
                {
                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    this.furnitureLoader(reader, furnitures);
                }
                finally
                {
                    command.Connection.Close();
                }

                return furnitures;
            }
        }

        /// <summary>
        /// Updates the quantities from list of ids.
        /// </summary>
        /// <param name="furnitureIdQuantities">The furniture identifier quantities.</param>
        public void UpdateQuantitiesFromListOfIds(IList<PurchaseTransaction_Item> furnitureId)
        {

            const string updateQuery = "UPDATE Furniture SET quantity=quantity - @Quantity WHERE id=@Id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(updateQuery))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    command.Parameters.Add("@Quantity", MySqlDbType.Int32);
                    command.Parameters.Add("@Id", MySqlDbType.Int32);

                    foreach (var item in furnitureId)
                    {
                        command.Parameters["@Id"].Value = item.FurnitureId;
                        command.Parameters["@Quantity"].Value = item.Quantity;
                        command.ExecuteNonQuery();
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }
    }
}