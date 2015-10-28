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

        public AddressController()
        {
            this.addressRepository = new AddressRepository();
        }

        public IList<Address> GetAllAddresses()
        {
            return this.addressRepository.GetAll();
        }

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
