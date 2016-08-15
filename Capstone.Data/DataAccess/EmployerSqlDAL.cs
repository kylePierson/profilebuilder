using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;

namespace Capstone.Data.DataAccess
{
    public class EmployerSqlDAL : IEmployerDAL
    {
        private string connectionString;

        private const string SQL_AddEmployerUser = @"INSERT INTO employer 
                                                    VALUES (@username, @firstname, @lastname);";

        private const string SQL_GetEmployer = @"select programming_language.name
                                    from employer
                                    inner join employer_language on employer.employer_id = employer_language.employer_id
                                    inner join programming_language on programming_language.programminglanguage_id = employer_language.programminglanguage_id
                                    where employer.username = @username;";

        private const string SQL_GetEmployer_CompanyName = @"select employer.company
                                    from employer
                                    inner join employer_language on employer.employer_id = employer_language.employer_id
                                    inner join programming_language on programming_language.programminglanguage_id = employer_language.programminglanguage_id
                                    where employer.username = @username;";

        private const string SQL_AddInterest = @"UPDATE employer_language
                                   SET programminglanguage_id = (SELECT programminglanguage_id FROM programming_language WHERE name =@interest)
                                    from employer_language
                                    inner join employer on employer.employer_id = employer_language.employer_id
                                    inner join programming_language on programming_language.programminglanguage_id = employer_language.programminglanguage_id
                                    where employer.username =@username ;";

        private const string SQL_DeleteInterest = @"DELETE FROM employer_language
                                from employer_language
                                inner join employer on employer.employer_id = employer_language.employer_id
                                inner join programming_language on programming_language.programminglanguage_id = employer_language.programminglanguage_id
                                where employer.username =@username and programming_language.name = @interest ;";

        public EmployerSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public EmployerSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public bool AddEmployerUser(string username, string firstName, string lastName, string company, string programingLanguge)
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
                    cmd.Parameters.AddWithValue("@programming_language", programingLanguge);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

            }
            return rowsAffected > 0;
        }

        public Employer GetEmployer(string username)
        {
            Employer currentEmployer = new Employer();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetEmployer, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<string> languages  = new List<string>();

                    while (reader.Read())
                    {
                        //currentEmployer.CompanyName = Convert.ToString(reader["company"]);
                        currentEmployer.Language= Convert.ToString(reader["name"]);
                        //currentEmployer.ContactFirstName = Convert.ToString(reader["contactFirstName"]);
                        //currentEmployer.ContactLastName = Convert.ToString(reader["contactLastName"]);
                        //currentEmployer.Address = Convert.ToString(reader["address"]);
                        //currentEmployer.ContactInfo = Convert.ToString(reader["contactInfo"]);
                        //currentEmployer.Username = Convert.ToString(reader["username"]);
                       languages.Add(currentEmployer.Language = Convert.ToString(reader["name"]));
                    }
                    currentEmployer.Programming_language = languages;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetEmployer_CompanyName, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        currentEmployer.CompanyName = Convert.ToString(reader["company"]);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return currentEmployer;
        }

        public bool AddInterest(string username, string interest)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddInterest, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@interest", interest);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

            }
            return rowsAffected > 0;
        }

        public bool DeleteInterest(string username, string interest)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_DeleteInterest, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@interest", interest);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

            }
            return rowsAffected > 0;
        }
    }
}
