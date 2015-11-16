using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class FurnitureRepository : IFurnitureRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FurnitureRepository" /> class.
        /// </summary>
        public FurnitureRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

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
                command.Parameters.AddWithValue("@cat", item.CategoryID);
                command.Parameters.AddWithValue("@style", item.StyleID);


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

            const string query = "SELECT * FROM Furniture";

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

        public Furniture GetById(string id)
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture WHERE id = @id";

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

        public void Delete(Furniture item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(Furniture item)
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
                command.Parameters.AddWithValue("@cat", item.CategoryID);
                command.Parameters.AddWithValue("@style", item.StyleID);
                command.Parameters.AddWithValue("@id", item.ID);


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
                furniture.ID = ((int) reader["id"]).ToString();
                furniture.Quantity = reader["quantity"] as uint? ?? uint.MinValue;
                furniture.Name = reader["name"] == DBNull.Value ? string.Empty : (string) reader["name"];
                furniture.Description = reader["description"] == DBNull.Value
                    ? string.Empty
                    : (string) reader["description"];
                furniture.Price = reader["price"] as decimal? ?? decimal.Zero;
                furniture.LateFee = reader["lateFee"] as decimal? ?? decimal.Zero;
                furniture.CategoryID = (reader["Category_id"] as int? ?? int.MinValue).ToString();
                furniture.StyleID = (reader["Style_id"] as int? ?? int.MinValue).ToString();

                furnitures.Add(furniture);
            }
        }

        public IList<Furniture> GetAllByCategoryStyleCriteria(Category category, Style style)
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture WHERE Category_id LIKE @cat AND Style_id LIKE @style";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@cat", category?.ID ?? "%");
                command.Parameters.AddWithValue("@style", style?.ID ?? "%");
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

        public IList<Furniture> GetAllByIDPrefix(int id)
        {
            var furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture WHERE id LIKE @id";

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

        public void UpdateQuantitiesFromListOfIds(Dictionary<string, int> furnitureIdQuantities)
        {
            //this.checkStock(furnitureIdQuantities);

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

                    foreach (var key in furnitureIdQuantities.Keys)
                    {
                        command.Parameters["@Id"].Value = int.Parse(key);
                        command.Parameters["@Quantity"].Value = furnitureIdQuantities[key];
                        command.ExecuteNonQuery();
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }

        private void checkStock(Dictionary<string, int> furnitureIdQuantities)
        {
            const string query = "SELECT quantity FROM Furniture WHERE id=@Id";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Parameters.Add("@Id", MySqlDbType.Int32);

                    command.Connection.Open();

                    foreach (var key in furnitureIdQuantities.Keys)
                    {
                        command.Parameters["@Id"].Value = int.Parse(key);
                        var reader = command.ExecuteReader();

                        var quantity = reader["quantity"] as uint? ?? uint.MinValue;

                        if (quantity < furnitureIdQuantities[key])
                        {
                            throw new ArgumentOutOfRangeException("You are trying to rent " + furnitureIdQuantities[key] +
                                " items of id " + key + ". There are only " + quantity + " of that item in stock.");
                        }
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