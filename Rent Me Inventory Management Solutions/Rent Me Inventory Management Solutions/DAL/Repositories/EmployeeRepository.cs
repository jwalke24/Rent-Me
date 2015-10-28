using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class EmployeeRepository : IRepository<Employee>
    {
        private readonly string CONNECTION_STRING;

        public EmployeeRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }


        public void AddOne(Employee item)
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<Employee> theList)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee item)
        {
            throw new NotImplementedException();
        }

        public LoginSession LoginEmployeeToDatabase(LoginSession theSession)
        {
            string sqlStatement = "SELECT id, isAdmin FROM Employee WHERE id = @Username AND password = @Password";

            MySqlConnection connection = new MySqlConnection(this.CONNECTION_STRING);

            MySqlCommand command = new MySqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@Username", theSession.Id);
            command.Parameters.AddWithValue("@Password", theSession.Password);

            command.Connection = connection;

            try
            {
                command.Connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                theSession.isAuthenticated = false;
                theSession.isAdmin = false;

                if (reader.HasRows)
                {
                    reader.Read();

                    if (theSession.Id == (int)reader["id"])
                    {
                        theSession.isAuthenticated = true;

                        if ((bool)reader["isAdmin"])
                        {
                            theSession.isAdmin = true;

                        }
                    }
                }
            }
            finally
            {
                command.Connection.Close();
            }

            return theSession;
        }
    }
}
