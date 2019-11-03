using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace BugTracker.Models
{
    public class User
    {
        public string Username { get; set; } //Must be unique, since it is used to login with. //Should I remove the ID, since I also use this to identify the Users with.
        public string Password { get; set; } //Has to have some minimum requirements as a password.
        public int Level { get; set; }

        public User(string username, string password, int level)
        {
            this.Level = level; this.Username = username; string _Password = password;
            this.Password = sha256_hash(_Password);
        }

        public User()
        {
            this.Username = ""; this.Password = ""; this.Level = 0;
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value + "E1Y8U7H6GGG43H32H46J21K")); //SALT included

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}