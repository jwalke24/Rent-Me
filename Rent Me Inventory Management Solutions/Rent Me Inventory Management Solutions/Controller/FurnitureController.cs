using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    /// <summary>
    /// This class is responsible for managing Furniture items and their repositories.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class FurnitureController
    {
        private readonly FurnitureRepository theRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FurnitureController" /> class.
        /// </summary>
        public FurnitureController()
        {
            this.theRepository = new FurnitureRepository();
        }

        /// <summary>
        ///     Gets all the furniture items from the database.
        /// </summary>
        /// <returns></returns>
        public IList<Furniture> GetAll()
        {
            return this.theRepository.GetAll();
        }

        /// <summary>
        /// Gets the items by category style.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="style">The style.</param>
        /// <returns></returns>
        public IList<Furniture> GetItemsByCategoryStyle(Category category, Style style)
        {
            return this.theRepository.GetAllByCategoryStyleCriteria(category, style);
        }

        /// <summary>
        /// Gets the items from identifier wildcard.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IList<Furniture> GetItemsFromIdWildcard(int id)
        {
            return this.theRepository.GetAllByIdPrefix(id);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="theCategory">The category.</param>
        /// <param name="theStyle">The style.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="lateFee">The late fee.</param>
        public void AddItem(Category theCategory, Style theStyle, string name, string description, decimal price,
            uint quantity, decimal lateFee)
        {
            var tempFurniture = new Furniture
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryId = theCategory.Id,
                StyleId = theStyle.Id,
                LateFee = lateFee
            };
            this.theRepository.AddOne(tempFurniture);
        }

        /// <summary>
        /// Deletes the furniture by identifier.
        /// </summary>
        /// <param name="deleteId">The delete identifier.</param>
        public void DeleteFurnitureById(string deleteId)
        {
            this.theRepository.DeleteById(deleteId);
        }

        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Furniture GetItemById(int id)
        {
            return this.theRepository.GetById(id.ToString());
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="theCategory">The category.</param>
        /// <param name="theStyle">The style.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="lateFee">The late fee.</param>
        /// <param name="itemId">The item identifier.</param>
        public void UpdateItem(Category theCategory, Style theStyle, string name, string description, decimal price, uint quantity, decimal lateFee, string itemId)
        {
            var tempFurniture = new Furniture
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryId = theCategory.Id,
                StyleId = theStyle.Id,
                LateFee = lateFee,
                Id = itemId
            };
            this.theRepository.UpdateById(tempFurniture);
        }

        /// <summary>
        /// Updates the quantities by ids.
        /// </summary>
        /// <param name="furnitureIdQuantities">The furniture identifier quantities.</param>
        public void UpdateQuantitiesByIds(Dictionary<string, int> furnitureIdQuantities)
        {
            this.theRepository.UpdateQuantitiesFromListOfIds(furnitureIdQuantities);
        }
    }
}