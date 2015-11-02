using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class EmployeeController
    {
        private EmployeeRepository employeeRepository;

        public EmployeeController()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        /// <summary>
        /// Validates the user on the network.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public LoginSession ValidateUserOnNetwork(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }

            return this.employeeRepository.LoginEmployeeToDatabase(new LoginSession(id, password));
        }

        /// <summary>
        /// Adds the employee to the database.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="password">The password.</param>
        public void AddEmployee(Employee employee, string password)
        {
            this.employeeRepository.AddOne(employee, new LoginSession(0,password));
        }

        /// <summary>
        /// Gets all the employees from the database.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetAll()
        {
            return this.employeeRepository.GetAll();
        }

        /// <summary>
        /// Deletes the employee by identifier.
        /// </summary>
        /// <param name="deleteId">The delete identifier.</param>
        public void DeleteEmployeeById(string deleteId)
        {
            this.employeeRepository.DeleteById(deleteId);
        }
    }
}
