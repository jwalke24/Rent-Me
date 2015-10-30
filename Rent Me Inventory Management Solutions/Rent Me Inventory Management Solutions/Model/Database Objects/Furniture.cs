using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    class Furniture
    {
        public string ID { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int StyleID { get; set; }
    }
}
