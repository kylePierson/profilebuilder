using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.DataAccess
{
    public class EmployerSqlDAL : IEmployerDAL
    {
        private string connectionString;

        private const string SQL_AddEmployerUser = "INSERT INTO employer VALUES (@username, @firstname, @lastname);";

        public EmployerSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public EmployerSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public bool AddEmployerUser(string username, string firstName, string lastName, string company)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddEmployerUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@company", company);

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
