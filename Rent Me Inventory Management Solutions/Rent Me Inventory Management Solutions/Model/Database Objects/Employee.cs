namespace Rent_Me_Inventory_Management_Solutions.Model.Database_Objects
{
    internal class Employee
    {
        public Employee ()
        {
            this.EmployeeAddress = new Address();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the SSN.
        /// </summary>
        /// <value>
        ///     The SSN.
        /// </value>
        public string SSN { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        public Address EmployeeAddress { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is admin.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is admin; otherwise, <c>false</c>.
        /// </value>
        public bool isAdmin { get; set; }
    }
}