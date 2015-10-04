using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    class LoginSession
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string username { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin; otherwise, <c>false</c>.
        /// </value>
        public bool isAdmin { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSession"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        public LoginSession(string username, bool isAdmin)
        {
            this.username = username;
            this.isAdmin = isAdmin;
        }
        
    }
}
