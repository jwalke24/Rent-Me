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
    class FurnitureRepository : IRepository<Furniture>
    {
        private readonly string CONNECTION_STRING;
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnitureRepository"/> class.
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

            const string statement = "INSERT INTO Furniture (quantity, name, description, price, lateFee, Category_id, Style_id)" +
                                        " VALUES (@quantity, @name, @description, @price, @late, @cat, @style)";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(statement))
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
        /// Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Furniture> GetAll()
        {
            List<Furniture> furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = connection;

                try
                {
                    command.Connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    furnitureLoader(reader, furnitures);
                }
                finally
                {
                    command.Connection.Close();
                }

                return furnitures;
            }
        }

        private void furnitureLoader(MySqlDataReader reader, List<Furniture> furnitures)
        {
            while (reader.Read())
            {
                Furniture furniture = new Furniture();
                furniture.ID = ((int) reader["id"]).ToString();
                furniture.Quantity = reader["quantity"] as uint? ?? uint.MinValue;
                furniture.Name = reader["name"] == DBNull.Value ? String.Empty : (string) reader["name"];
                furniture.Description = reader["description"] == DBNull.Value
                    ? String.Empty
                    : (string) reader["description"];
                furniture.Price = reader["price"] as Decimal? ?? Decimal.Zero;
                furniture.LateFee = reader["lateFee"] as Decimal? ?? Decimal.Zero;
                furniture.CategoryID = (reader["Category_id"] as int? ?? Int32.MinValue).ToString();
                furniture.StyleID = (reader["Style_id"] as int? ?? Int32.MinValue).ToString();

                furnitures.Add(furniture);
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

        public IList<Furniture> GetAllByCategoryStyleCriteria(Category category, Style style)
        {
            List<Furniture> furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture WHERE Category_id LIKE @cat AND Style_id LIKE @style";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@cat", category?.ID ?? "%");
                command.Parameters.AddWithValue("@style", style?.ID ?? "%");
                try
                {
                    command.Connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

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
            List<Furniture> furnitures = new List<Furniture>();

            const string query = "SELECT * FROM Furniture WHERE id LIKE @id";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            using (MySqlCommand command = new MySqlCommand(query))
            {
                command.Connection = connection;

                command.Parameters.AddWithValue("@id", id.ToString() + "%");
                try
                {
                    command.Connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

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
