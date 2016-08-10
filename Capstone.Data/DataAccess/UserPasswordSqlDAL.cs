using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Data.DataAccess
{
    public class UserPasswordSqlDAL : IUserPasswordDAL
    {
        private string connectionString;
        private const string SQL_GetUser = "SELECT * FROM user_password WHERE @username=username AND @password=password;";
        private const string SQL_AddUser = "INSERT INTO user_password VALUES (@username, @password, @roleTitle);";
        private const string SQL_GetUserByUsername = "SELECT * FROM user_password WHERE @username=username;";


        public UserPasswordSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public UserPasswordSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public UserPassword GetUser(string username, string password)
        {
            UserPassword output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new UserPassword();
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
                        output.RoleTitle = Convert.ToString(reader["role_title"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public UserPassword GetUser(string username)
        {
            UserPassword output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetUserByUsername, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new UserPassword();
                        output.Username = Convert.ToString(reader["username"]);
                        output.Password = Convert.ToString(reader["password"]);
                        output.RoleTitle = Convert.ToString(reader["role_title"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public bool AddUser(string username, string password, string role)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@roleTitle", role);
                    cmd.Parameters.AddWithValue("@password", password);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return rowsAffected > 0;
        }
    }
}
