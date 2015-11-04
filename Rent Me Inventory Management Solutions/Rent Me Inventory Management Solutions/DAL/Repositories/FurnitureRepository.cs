using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class FurnitureRepository : IRepository<Furniture>
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FurnitureRepository" /> class.
        /// </summary>
        public FurnitureRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public void AddOne(Furniture item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(@"Item is null");
            }

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
                }
                finally
                {
                    command.Connection.Close();
                }
            }
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
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Furniture item)
        {
            throw new NotImplementedException();
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
    }
}