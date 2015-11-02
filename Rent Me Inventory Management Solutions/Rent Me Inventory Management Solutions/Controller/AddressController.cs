using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class AddressController
    {
        private AddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        public AddressController()
        {
            this.addressRepository = new AddressRepository();
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns></returns>
        public IList<Address> GetAllAddresses()
        {
            return this.addressRepository.GetAll();
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="street1">The street1.</param>
        /// <param name="street2">The street2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        public void AddAddress(string street1, string street2, string city, string state, string zip)
        {
            Address newAddress = new Address
            {
                City = street1,
                State = state,
                Street1 = street1,
                Street2 = street2,
                Zip = zip
            };
            this.addressRepository.AddOne(newAddress);
        }
    }
}
