using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    class Employee
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber  { get; set; }
        public string  AddressId { get; set; }
        public bool isAdmin { get; set; }

    }
}
