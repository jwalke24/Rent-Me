using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IRepository<T>
    {

        void AddOne(T item);

        void AddList(IList<T> theList);

        IList<T> GetAll();

        T GetById(string id);

        void DeleteById(string id);

        void Delete(T item);

    }
}
