using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IFurnitureRepository : IRepository<Furniture>
    {
        IList<Furniture> GetAllByIDPrefix(int id);

        IList<Furniture> GetAllByCategoryStyleCriteria(Category category, Style style);

        void UpdateQuantitiesFromListOfIds(Dictionary<string, int> furnitureIdQuantities);
    }
}
