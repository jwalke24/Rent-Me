using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class StyleRepository : IRepository<Style>
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
                        style.ID = ((int) reader["id"]).ToString();
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

        public void UpdateByID(Style item)
        {
            throw new NotImplementedException();
        }
    }
}