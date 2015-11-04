using System;
using System.Security.Cryptography;
using System.Text;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    public class LoginSession
    {
        public int Id { get; }
        public bool isAuthenticated { get; set; }
        public bool isAdmin { get; set; }

        public string Password
        {
            get { return this.password; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                this.password = this.hashPassword(value);
            }
        }

        private string password;

        public LoginSession(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }

            this.Id = id;
            this.Password = password;
        }

        public LoginSession()
        {
        }

        private string hashPassword(string value)
        {
            var Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(value));

                foreach (var b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }

            return Sb.ToString();
        }
    }
}