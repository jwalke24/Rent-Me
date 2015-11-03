using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class FurnitureController
    {
        private FurnitureRepository theRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FurnitureController"/> class.
        /// </summary>
        public FurnitureController()
        {
            theRepository = new FurnitureRepository();
        }
        /// <summary>
        /// Gets all the furniture items from the database.
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

        public void AddItem(Category theCategory, Style theStyle, string name, string description, decimal price, uint quantity)
        {
            Furniture tempFurniture = new Furniture
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryID = theCategory.ID,
                StyleID = theStyle.ID
            };
            this.theRepository.AddOne(tempFurniture);
        }
    }
}
