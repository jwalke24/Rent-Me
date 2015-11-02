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
            throw new NotImplementedException();
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
                        ;
                        furniture.CategoryID = reader["Category_id"] as int? ?? Int32.MinValue;
                        furniture.StyleID = reader["Style_id"] as int? ?? Int32.MinValue;

                        furnitures.Add(furniture);
                    }
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
    }
}
