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
                        output.CityId = Convert.ToInt32(reader["id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.CountryCode = Convert.ToString(reader["countrycode"]);
                        output.District = Convert.ToString(reader["district"]);
                        output.Population = Convert.ToInt32(reader["population"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }
    }
}
