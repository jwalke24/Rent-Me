using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    class Customer
    {
        public string Fname { get; set; }

        public string Minit { get; set; }

        public string Lname { get; set; }

        public string PhoneNumber { get; set; }

        public Address TheAddress { get; set; }
    }
}
