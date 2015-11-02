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
    }
}
