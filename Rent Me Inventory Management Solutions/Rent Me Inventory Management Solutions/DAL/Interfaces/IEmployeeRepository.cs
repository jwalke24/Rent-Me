using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IEmployeeRepository : IRepository<Employee>
    {
        LoginSession LoginEmployeeToDatabase(LoginSession theSession);

        void AddOne(Employee employee, LoginSession loginSession);
    }
}
