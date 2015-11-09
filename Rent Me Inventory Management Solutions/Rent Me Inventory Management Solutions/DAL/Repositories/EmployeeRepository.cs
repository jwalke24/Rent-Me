using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmployeeRepository" /> class.
        /// </summary>
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

        /// <summary>
        ///     Gets all the items in the database.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetAll()
        {
            var employees = new List<Employee>();

            const string query = "SELECT fname, lname, ssn, phone, isAdmin, id, Address_id FROM Employee";

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
                        var employee = new Employee();
                        employee.ID = ((int) reader["id"]).ToString();
                        employee.FirstName = reader["fname"] == DBNull.Value ? string.Empty : (string) reader["fname"];
                        employee.LastName = reader["lname"] == DBNull.Value ? string.Empty : (string) reader["lname"];
                        employee.PhoneNumber = reader["phone"] == DBNull.Value ? string.Empty : (string) reader["phone"];
                        employee.AddressId = reader["Address_id"] == DBNull.Value
                            ? string.Empty
                            : ((int) reader["Address_id"]).ToString();
                        employee.SSN = reader["ssn"] == DBNull.Value ? string.Empty : (string) reader["ssn"];
                        employee.isAdmin = reader["isAdmin"] == DBNull.Value ? false : (bool) reader["isAdmin"];

                        employees.Add(employee);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return employees;
        }

        public Employee GetById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteById(string id)
        {
            var sqlStatement = "DELETE FROM Employee WHERE id = @id";

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

        public void Delete(Employee item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(Employee item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds the one.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="loginSession">The login session.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddOne(Employee employee, LoginSession loginSession)
        {
            if (employee == null || loginSession == null || loginSession.Password == null)
            {
                throw new ArgumentNullException();
            }

            const string statement = "INSERT INTO Employee (fname, lname, phone, Address_id, isAdmin, ssn, password)" +
                                     " VALUES (@Fname, @Lname, @Phone, @Address, @Admin, @Ssn, @Password)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@Fname", employee.FirstName);
                command.Parameters.AddWithValue("@Lname", employee.LastName);
                command.Parameters.AddWithValue("@Phone", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Address", employee.AddressId);
                command.Parameters.AddWithValue("@Admin", employee.isAdmin);
                command.Parameters.AddWithValue("@Ssn", employee.SSN);
                command.Parameters.AddWithValue("@Password", loginSession.Password);

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

        /// <summary>
        ///     Logs in the employee to database.
        /// </summary>
        /// <param name="theSession">The session.</param>
        /// <returns></returns>
        public LoginSession LoginEmployeeToDatabase(LoginSession theSession)
        {
            var sqlStatement = "SELECT id, isAdmin FROM Employee WHERE id = @Username AND password = @Password";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            var command = new MySqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@Username", theSession.Id);
            command.Parameters.AddWithValue("@Password", theSession.Password);

            command.Connection = connection;

            try
            {
                command.Connection.Open();

                var reader = command.ExecuteReader();

                theSession.isAuthenticated = false;
                theSession.isAdmin = false;

                if (reader.HasRows)
                {
                    reader.Read();

                    if (theSession.Id == (int) reader["id"])
                    {
                        theSession.isAuthenticated = true;

                        if ((bool) reader["isAdmin"])
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