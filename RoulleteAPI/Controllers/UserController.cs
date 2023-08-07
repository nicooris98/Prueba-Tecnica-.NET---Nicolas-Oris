using RoulleteAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static System.Net.Mime.MediaTypeNames;

namespace RoulleteAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public UserModel Get(string username)
        {
            string connstring = "Data Source = DESKTOP-NDERDM3\\SQLEXPRESS; Initial Catalog=roullete_casino;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string query = "select top(1) * from Users where username = '"+username+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            UserModel user = new UserModel();
            while(reader.Read())
            {
                user.username = Convert.ToString(reader["username"]);
                user.amount = Convert.ToDouble(reader["amount"]);
            }
            reader.Close();
            if(user.username == null)
            {
                string insertQuery = "insert into Users(username) values ('"+username+"')";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.username = Convert.ToString(reader["username"]);
                    user.amount = Convert.ToDouble(reader["amount"]);
                }
                reader.Close();
            }
            conn.Close();
            return user;
        }

        public UserModel Put(string username, [FromBody] string newAmount)
        {
            string connstring = "Data Source = DESKTOP-NDERDM3\\SQLEXPRESS; Initial Catalog=roullete_casino;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string query = "update Users set amount = "+ newAmount + " where username = '" + username + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            query = "select top(1) * from Users where username = '"+username+"'";
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            UserModel user = new UserModel();
            while (reader.Read())
            {
                user.username = Convert.ToString(reader["username"]);
                user.amount = Convert.ToDouble(reader["amount"]);
            }
            reader.Close();
            conn.Close();
            return user;
        }
    }
}
