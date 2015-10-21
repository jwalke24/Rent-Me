using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Network;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class NetworkController
    {
        private SqlNetwork theNetwork;

        public NetworkController()
        {
            this.theNetwork = new SqlNetwork();
        }

        public LoginSession ValidateUserOnNetwork(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }






            return this.theNetwork.loginEmployeeToDatabase(new LoginSession(id, password));
        }
    }
}
