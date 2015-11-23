using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Member Repository.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IMemberRepository : IRepository<Member>
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
        IList<Member> SearchByIdOrPhone(string id);
    }
}
