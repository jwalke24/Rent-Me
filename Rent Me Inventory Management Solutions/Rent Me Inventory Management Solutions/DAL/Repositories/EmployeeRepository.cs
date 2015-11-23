using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    /// <summary>
    /// This class is responsible for querying Employees with the database.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly string CONNECTION_STRING;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmployeeRepository" /> class.
        /// </summary>
        public EmployeeRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddOne(Employee item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        /// <exception cref="NotImplementedException"></exception>
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

            const string query = "SELECT Employee.fname, Employee.lname, Employee.ssn, Employee.phone, Employee.IsAdmin, Employee.id, Employee.Address_id, " +
                                 "Address.* " + 
                                 "FROM Employee, Address " + 
                                 "WHERE Employee.Address_id = Address.id";

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
                        employee.Id = ((int) reader["id"]).ToString();
                        employee.FirstName = reader["fname"] == DBNull.Value ? string.Empty : (string) reader["fname"];
                        employee.LastName = reader["lname"] == DBNull.Value ? string.Empty : (string) reader["lname"];
                        employee.PhoneNumber = reader["phone"] == DBNull.Value ? string.Empty : (string) reader["phone"];

                        this.loadAddress(employee, reader);

                        employee.SSN = reader["ssn"] == DBNull.Value ? string.Empty : (string) reader["ssn"];
                        employee.IsAdmin = reader["IsAdmin"] == DBNull.Value ? false : (bool) reader["IsAdmin"];

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

        private void loadAddress(Employee employee, MySqlDataReader reader)
        {
            employee.EmployeeAddress.Id = reader["Address_id"] == DBNull.Value
                ? string.Empty
                : reader["Address_id"].ToString();
            employee.EmployeeAddress.Street1 = reader["street1"] == DBNull.Value
                ? string.Empty
                : reader["street1"].ToString();
            employee.EmployeeAddress.Street2 = reader["street2"] == DBNull.Value
                ? string.Empty
                : reader["street2"].ToString();
            employee.EmployeeAddress.City = reader["city"] == DBNull.Value
                ? string.Empty
                : reader["city"].ToString();
            employee.EmployeeAddress.State = reader["state"] == DBNull.Value
                ? string.Empty
                : reader["state"].ToString();
            employee.EmployeeAddress.Zip = reader["zip"] == DBNull.Value
                ? string.Empty
                : reader["zip"].ToString();
        }

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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

        /// <summary>
        /// Updates the item by identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateById(Employee item)
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

            const string statement = "INSERT INTO Employee (fname, lname, phone, Address_id, IsAdmin, ssn, password)" +
                                     " VALUES (@Fname, @Lname, @Phone, @Address, @Admin, @Ssn, @Password)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Parameters.AddWithValue("@Fname", employee.FirstName);
                command.Parameters.AddWithValue("@Lname", employee.LastName);
                command.Parameters.AddWithValue("@Phone", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Address", employee.EmployeeAddress.Id);
                command.Parameters.AddWithValue("@Admin", employee.IsAdmin);
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
            var sqlStatement = "SELECT id, IsAdmin FROM Employee WHERE id = @Username AND password = @Password";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            var command = new MySqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@Username", theSession.Id);
            command.Parameters.AddWithValue("@Password", theSession.Password);

            command.Connection = connection;

            try
            {
                command.Connection.Open();

                var reader = command.ExecuteReader();

                theSession.IsAuthenticated = false;
                theSession.IsAdmin = false;

                if (reader.HasRows)
                {
                    reader.Read();

                    if (theSession.Id == (int) reader["id"])
                    {
                        theSession.IsAuthenticated = true;

                        if ((bool) reader["IsAdmin"])
                        {
                            theSession.IsAdmin = true;
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