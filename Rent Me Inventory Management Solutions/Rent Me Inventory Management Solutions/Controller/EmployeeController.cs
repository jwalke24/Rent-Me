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

        public LoginSession ValidateUserOnNetwork(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }

            return this.employeeRepository.LoginEmployeeToDatabase(new LoginSession(id, password));
        }

        public void AddEmployee(Employee employee, string password)
        {
            this.employeeRepository.AddOne(employee, new LoginSession(0,password));
        }

        public IList<Employee> GetAll()
        {
            return this.employeeRepository.GetAll();
        }

        public void DeleteEmployeeById(string deleteId)
        {
            this.employeeRepository.DeleteById(deleteId);
        }
    }
}
