using System.Collections.Generic;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    /// <summary>
    /// This class is responsible for managing Categories and Sytles and their respective repositories.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class CategoryStyleController
    {
        private readonly CategoryRepository categoryRepository;
        private readonly StyleRepository styleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryStyleController"/> class.
        /// </summary>
        public CategoryStyleController()
        {
            this.categoryRepository = new CategoryRepository();
            this.styleRepository = new StyleRepository();
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllCategories()
        {
            return this.categoryRepository.GetAll();
        }

        /// <summary>
        /// Gets all styles.
        /// </summary>
        /// <returns></returns>
        public IList<Style> GetAllStyles()
        {
            return this.styleRepository.GetAll();
        }
    }
}