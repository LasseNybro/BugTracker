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
        public int ID { get; set; } //Must be unique, since it is used to find reported problems with and also messages.
        public string Level { get; set; }
        public string Name { get; set; } //Must be unique, since it is used to login with. //Should I remove the ID, since I also use this to identify the Users with.
        public string Password { get; set; } //Has to have some minimum requirements as a password.
        User(int id, string level, string name, string password)
        {
            ID = id; Level = level; Name = name; string _Password = password;
            Password = sha256_hash(_Password+"E1Y8U7H6GGG43H32H46J21K");
        }
        public static String sha256_hash(String value)
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