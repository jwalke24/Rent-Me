using System.Collections.Generic;
using System.ComponentModel;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    /// <summary>
    /// This is an interface for the Furniture Repository class.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal interface IFurnitureRepository : IRepository<Furniture>
    {
        /// <summary>
        /// Gets all by identifier prefix.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<Furniture> GetAllByIdPrefix(int id);

        /// <summary>
        /// Gets all by category style criteria.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="style">The style.</param>
        /// <returns></returns>
        IList<Furniture> GetAllByCategoryStyleCriteria(Category category, Style style);

        /// <summary>
        /// Updates the quantities from list of ids.
        /// </summary>
        /// <param name="furnitureIdQuantities">The furniture identifier quantities.</param>
        void UpdateQuantitiesFromListOfIds(IList<PurchaseTransaction_Item> furnitureIdQuantities);
    }
}
