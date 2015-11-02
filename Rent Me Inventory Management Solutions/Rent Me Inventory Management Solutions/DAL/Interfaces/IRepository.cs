using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IRepository<T>
    {

        /// <summary>
        /// Adds one item to the database.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddOne(T item);

        /// <summary>
        /// Adds a list of items to the database.
        /// </summary>
        /// <param name="theList">The list.</param>
        void AddList(IList<T> theList);

        /// <summary>
        /// Gets all the items in the database. 
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Gets the item from the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetById(string id);

        /// <summary>
        /// Deletes the item from the database by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteById(string id);

        /// <summary>
        /// Deletes the specified item from the database.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(T item);

    }
}
