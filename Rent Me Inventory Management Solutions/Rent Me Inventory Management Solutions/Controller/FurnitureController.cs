using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
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

        public IList<Furniture> GetItemsByCategoryStyle(Category category, Style style)
        {
            return this.theRepository.GetAllByCategoryStyleCriteria(category, style);
        }

        public IList<Furniture> GetItemsFromIDWildcard(int id)
        {
            return this.theRepository.GetAllByIDPrefix(id);
        }

        public void AddItem(Category theCategory, Style theStyle, string name, string description, decimal price,
            uint quantity, decimal lateFee)
        {
            var tempFurniture = new Furniture
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryID = theCategory.ID,
                StyleID = theStyle.ID,
                LateFee = lateFee
            };
            this.theRepository.AddOne(tempFurniture);
        }

        public void DeleteFurnitureById(string deleteId)
        {
            this.theRepository.DeleteById(deleteId);
        }

        public Furniture GetItemById(int id)
        {
            return this.theRepository.GetById(id.ToString());
        }
    }
}