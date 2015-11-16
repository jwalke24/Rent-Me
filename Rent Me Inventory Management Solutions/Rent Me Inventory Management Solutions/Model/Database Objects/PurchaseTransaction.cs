using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class PurchaseTransaction
    {
        public string ID { get; set; }
        public DateTime TransactionTime { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public List<PurchaseTransaction_Item> Items { get; set; } 
    }
}
