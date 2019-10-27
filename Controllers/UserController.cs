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
            //Get the information from the Database

            //Convert the information into a User Object

            //return a JSON conversion of the User Object
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public JSON Get(int id)
        {
            //Get the information from the Database from the User id?

            //Convert the information into a User Object

            //return a JSON conversion of the User Object

            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            //Get the information from the Database from the User id?

            //Compare SHA256 encrypted passwords, include SALT string in the testee, continue if passwords match otherwise break it off here.

            //Convert the information into a User Object

            //return a JSON conversion of the User Object

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
}
