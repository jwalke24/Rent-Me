using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

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
            string sqlStatement = "SELECT id FROM Employee WHERE id = @Username AND password = @Password";

            if (theSession == null)
            {
                throw new NullReferenceException();
            }

            MySqlConnection conn = new MySqlConnection(this.CONNECTION_STRING);

            MySqlCommand cmd = new MySqlCommand(sqlStatement);

            cmd.Parameters.AddWithValue("@Username", theSession.Id);
            cmd.Parameters.AddWithValue("@Password", theSession.Password);

            cmd.Connection = conn;

            try
            {
                cmd.Connection.Open();
                var empID = cmd.ExecuteScalar();

                if (empID == null || ((int)empID) != theSession.Id)
                {
                    theSession.isAuthenticated = false;
                }
                else
                {
                    theSession.isAuthenticated = true;
                }
            }
            catch (Exception e)
            {
                theSession.isAuthenticated = false;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return theSession;
        }
    }
}
