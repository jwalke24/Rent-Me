using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    class LoginSession
    {
        public LoginSession(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }

            this.Id = id;
            this.Password = password;
        }

        public int Id { get;}

        private string password;

        public bool isAuthenticated { get; set; }

        public bool isAdmin { get; set; }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                this.password = this.hashPassword(value);
            }
        }

        private string hashPassword(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
