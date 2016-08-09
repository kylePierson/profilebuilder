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
    public class StaffSqlDAL : IStaffDAL
    {
        private string connectionString;
        private const string SQL_GetUser = "SELECT * FROM staff WHERE @username=username;";

        public StaffSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public StaffSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public Staff GetStaff(string username)
        {
            Staff output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Staff();
                        output.StaffId = Convert.ToInt32(reader["staff_id"]);
                        output.FirstName = Convert.ToString(reader["firstname"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.LastName = Convert.ToString(reader["lastname"]);
                        output.Title = Convert.ToString(reader["title"]);
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
