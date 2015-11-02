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

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the street1.
        /// </summary>
        /// <value>
        /// The street1.
        /// </value>
        public string Street1 { get; set; }

        /// <summary>
        /// Gets or sets the street2.
        /// </summary>
        /// <value>
        /// The street2.
        /// </value>
        public string Street2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        /// <exception cref="ArgumentException">Returns an error if the length does not equal 2.</exception>
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

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        /// <exception cref="ArgumentException">Returns an error if the length does not equal 5.</exception>
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
