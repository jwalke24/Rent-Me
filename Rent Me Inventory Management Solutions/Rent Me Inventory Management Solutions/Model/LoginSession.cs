using System;
using System.Security.Cryptography;
using System.Text;

namespace Rent_Me_Inventory_Management_Solutions.Model
{
    /// <summary>
    /// This class represents a specific login session of the application.
    /// </summary>
    /// <author>Jonah Nestrick and Jonathan Walker</author>
    /// <version>Fall 2015</version>
    public class LoginSession
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin; otherwise, <c>false</c>.
        /// </value>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <exception cref="NullReferenceException"></exception>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSession"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="NullReferenceException"></exception>
        public LoginSession(int id, string password)
        {
            if (password == null)
            {
                throw new NullReferenceException();
            }

            this.Id = id;
            this.Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSession"/> class.
        /// </summary>
        public LoginSession()
        {
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string hashPassword(string value)
        {
            var builder = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(value));

                foreach (var b in result)
                {
                    builder.Append(b.ToString("x2"));
                }
            }

            return builder.ToString();
        }
    }
}