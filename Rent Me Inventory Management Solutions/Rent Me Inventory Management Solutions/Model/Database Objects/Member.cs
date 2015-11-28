using System;

namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    /// <summary>
    /// This class represents a Member of RentMe Furniture.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    internal class Member
    {
        private string phoneNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        public Member()
        {
            this.MemberAddress = new Address();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the fname.
        /// </summary>
        /// <value>
        ///     The fname.
        /// </value>
        public string Fname { get; set; }

        /// <summary>
        ///     Gets or sets the minit.
        /// </summary>
        /// <value>
        ///     The minit.
        /// </value>
        public string Minit { get; set; }

        /// <summary>
        ///     Gets or sets the lname.
        /// </summary>
        /// <value>
        ///     The lname.
        /// </value>
        public string Lname { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid phone number");
                }

                try
                {

                    long.Parse(value);
                    this.phoneNumber = value;

                }
                catch
                {
                    throw new ArgumentException("Invalid phone number");
                }
            }
        }

        /// <summary>
        /// Gets or sets the member address.
        /// </summary>
        /// <value>
        /// The member address.
        /// </value>
        public Address MemberAddress { get; set; }
    }
}