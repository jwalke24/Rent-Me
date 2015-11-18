using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IPurchaseTransactionRepository : IRepository<PurchaseTransaction>
    {
        IList<PurchaseTransaction> GetTransactionsByCustomerID(string id);
    }
}
