using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class CategoryStyleController
    {
        private CategoryRepository categoryRepository;
        private StyleRepository styleRepository;
        public CategoryStyleController ()
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
