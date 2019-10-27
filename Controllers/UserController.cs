using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.Controllers
{
    public class UserController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            // Some way of logging into this program, include security later
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    class User
    {
        int ID = 0; //Must be unique, since it is used to find reported problems with and also messages.
        string Level = "User";
        string Name = ""; //Must be unique, since it is used to login with.
        string Password = ""; //Has to have some minimum requirements as a password.
        User(int id, string level, string name, string password)
        {
            ID = id; Level = level;Name = name;Password = password;
        }
    }
}
