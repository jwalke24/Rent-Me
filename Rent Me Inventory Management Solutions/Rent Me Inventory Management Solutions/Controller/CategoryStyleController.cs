using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    internal class CategoryStyleController
    {
        private readonly CategoryRepository categoryRepository;
        private readonly StyleRepository styleRepository;

        public CategoryStyleController()
        {
            this.categoryRepository = new CategoryRepository();
            this.styleRepository = new StyleRepository();
        }

        public IList<Category> GetAllCategories()
        {
            return this.categoryRepository.GetAll();
        }

        public IList<Style> GetAllStyles()
        {
            return this.styleRepository.GetAll();
        }
    }
}