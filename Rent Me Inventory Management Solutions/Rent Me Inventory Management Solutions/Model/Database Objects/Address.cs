using System;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    /// <summary>
    /// This class represents an Address for an Employee or Member of RentMe Furniture.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class Address
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the street1.
        /// </summary>
        /// <value>
        ///     The street1.
        /// </value>
        public string Street1 { get; set; }

        /// <summary>
        ///     Gets or sets the street2.
        /// </summary>
        /// <value>
        ///     The street2.
        /// </value>
        public string Street2 { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>
        ///     The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        /// <exception cref="ArgumentException">Returns an error if the length does not equal 2.</exception>
        public string State
        {
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
        ///     Gets or sets the zip.
        /// </summary>
        /// <value>
        ///     The zip.
        /// </value>
        /// <exception cref="ArgumentException">Returns an error if the length does not equal 5.</exception>
        public string Zip
        {
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

        private string state;
        private string zip;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string address = "";

            if (string.IsNullOrEmpty(this.Street2))
            {
                address = this.Street1 + ", " + this.City + ", " + this.State + " " + this.Zip;
            }
            else
            {
                address = this.Street1 + ", " + this.Street2 + ", " + this.City + ", " + this.State + " " + this.Zip;
            }

            return address;
        }
    }
}