using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace BugTracker.Controllers
{
    public class UserController : Controller
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
        [HttpGet]
        public JsonResult Get(string value)
        {
            string Conn = BuildConn();

            string queryString = "SELECT Username, Level FROM UserTable WHERE UserName=@username;";

            Models.User CurrUser = new Models.User();

            using (SqlConnection connection = new SqlConnection(BuildConn()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 20);
                command.Parameters["@username"].Value = value.Username;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        CurrUser.Username = reader["Username"].ToString();
                        CurrUser.Password = "";
                        CurrUser.Level = int.Parse(reader["Level"].ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return Json(CurrUser);

            //Get the information from the Database from the User id? DONE

            //Convert the information into a User Object. DONE

            //return a JSON conversion of the User Object. DONE
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post(string value)
        {
            //Compare SHA256 encrypted passwords, include SALT string in the testee, continue if passwords match otherwise break it off here. DONE

            //Convert the information into a User Object. DONE

            //return a JSON conversion of the User Object. DONE

            // Some way of logging into this program, include security later. DONE

            //Convert incoming string to User Object. DONE

            string Conn = BuildConn();

            string queryString = "SELECT * FROM UserTable WHERE UserName=@username;";

            Models.User CurrUser = new Models.User();

            using (SqlConnection connection = new SqlConnection(BuildConn()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 20);
                command.Parameters["@username"].Value = value.Username;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        CurrUser.Username = reader["Username"].ToString();
                        CurrUser.Password = reader["Password"].ToString();
                        CurrUser.Level = int.Parse(reader["Level"].ToString());
                    }
                    if (Models.User.sha256_hash(value.Password) != CurrUser.Password)
                    {
                        throw new Exception("Wrong Password.");
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return Json(CurrUser);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, string value)
        {
            //Creating a new User //Perhaps a way to update existing users?
            //Creating Users
            Models.User CurrUser = new Models.User(value.username, value.password, 0);
            //Convert incoming string to User Object. DONE

            string Conn = BuildConn();

            string queryString = "INSERT INTO UserTable(UserName,Password,Level) VALUES(@username,@password,@level);";

            using (SqlConnection connection = new SqlConnection(BuildConn()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 20);
                command.Parameters["@username"].Value = CurrUser.Username;
                command.Parameters.Add("@password", SqlDbType.Char, 64);
                command.Parameters["@password"].Value = CurrUser.Password;
                command.Parameters.Add("@level", SqlDbType.Int);
                command.Parameters["@level"].Value = CurrUser.Level;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(string value)
        {
            string Conn = BuildConn();

            string queryString = "SELECT * FROM UserTable WHERE UserName=@username;";

            Models.User CurrUser = new Models.User();

            using (SqlConnection connection = new SqlConnection(BuildConn()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 20);
                command.Parameters["@username"].Value = value.Username;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        CurrUser.Username = reader["Username"].ToString();
                        CurrUser.Password = reader["Password"].ToString();
                        CurrUser.Level = int.Parse(reader["Level"].ToString());
                    }
                    if (Models.User.sha256_hash(value.Password) != CurrUser.Password)
                    {
                        throw new Exception("Wrong Password.");
                    }
                }
                finally
                {
                    reader.Close();
                }
                queryString = "DELETE * FROM UserTable WHERE UserName=@username;";
                command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 20);
                command.Parameters["@username"].Value = value.Username;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static string BuildConn()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["InitialCatalog"] = "Users";
            //builder["Password"] =
            //builder["UserID"] = 
            builder["IntegratedSecurity"] = true;
            builder["AttachDBFilename"] = "..\\App_Data\\BugTrackerDB.mdf";

            return builder.ConnectionString;
        }
    }
}
