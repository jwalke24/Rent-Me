using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Employee Repository class.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Logins the employee to database.
        /// </summary>
        /// <param name="theSession">The session.</param>
        /// <returns></returns>
        LoginSession LoginEmployeeToDatabase(LoginSession theSession);

        /// <summary>
        /// Adds the one.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="loginSession">The login session.</param>
        void AddOne(Employee employee, LoginSession loginSession);
    }
}
