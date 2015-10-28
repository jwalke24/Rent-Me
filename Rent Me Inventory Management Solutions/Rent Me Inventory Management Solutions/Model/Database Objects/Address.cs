using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    class Address
    {

        private string state;
        private string zip;
        private int id;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State {
            get { return this.state; }
            set
            {
                if (value.Length != 2)
                {
                    throw new ArgumentException();
                }
                this.state = value;
            }
        }

        public string Zip {
            get { return this.zip; }
            set
            {
                if (value.Length != 5)
                {
                    throw new ArgumentException();
                }
                this.zip = value;
            }
        }
    }
}
