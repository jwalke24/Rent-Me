using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class PurchaseTransaction_Item
    {
        public string FurnitureID { get; set; }
        public int Quantity { get; set; }
        public int LeaseTime { get; set; }

        [Browsable(false)]
        public string PurchaseTransactionID { get; set; }
    }
}
