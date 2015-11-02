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
    class StyleRepository : IRepository<Style>
    {
        private readonly string CONNECTION_STRING;
        public StyleRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }
        public void AddOne(Style item)
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<Style> theList)
        {
            throw new NotImplementedException();
        }

        public IList<Style> GetAll()
        {
            List<Style> styles = new List<Style>();

            const string query = "SELECT * FROM Style";

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
                        Style style = new Style();
                        style.ID = ((int)reader["id"]).ToString();
                        style.Name = reader["name"] == DBNull.Value ? String.Empty : (string)reader["name"];
                        style.Description = reader["description"] == DBNull.Value
                            ? String.Empty
                            : (string)reader["description"];

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

        public Style GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Style item)
        {
            throw new NotImplementedException();
        }
    }
}
