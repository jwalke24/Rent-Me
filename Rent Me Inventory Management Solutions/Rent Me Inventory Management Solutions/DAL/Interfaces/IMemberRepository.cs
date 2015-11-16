using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IMemberRepository : IRepository<Member>
    {
        /// <summary>
        /// Searches the database by name for a customer.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        IList<Member> SearchByName(string text);

        /// <summary>
        /// Searches the database by identifier or phone.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<Member> SearchByIDOrPhone(string id);
    }
}
