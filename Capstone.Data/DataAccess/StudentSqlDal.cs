using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Data.DataAccess
{
    public class StudentSqlDAL : IStudentDAL
    {
        private string connectionString;
        //edit query to be long version of input
        private const string SQL_AddStudentUser = "INSERT INTO student (username, firstname, lastname, class) VALUES (@username, @firstname, @lastname, @class);";
        private const string SQL_UpdateStudentUser = "UPDATE student SET summary=@summary, previousexperience=@previousExperience, degree=@degree, contactinfo=@contactInfo, skill=@skills, interests=@interests where username = @username";
        private const string SQL_GetAllStudents = "";
        private const string SQL_GetStudent = "SELECT * FROM student WHERE @username=username;";
        public StudentSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public StudentSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddStudentUser(string username, string firstName, string lastName, string cohort)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddStudentUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@class", cohort);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> output = new List<Student>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_GetAllStudents;
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student s = CreateStudentFromReader(reader);
                        output.Add(s);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        private Student CreateStudentFromReader(SqlDataReader reader)
        {
            Student s = new Student();
            s.
            //s.Code = Convert.ToString(reader["code"]);
            //s.Name = Convert.ToString(reader["name"]);
            //s.Continent = Convert.ToString(reader["continent"]);
            //s.Region = Convert.ToString(reader["region"]);
            //s.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            //s.Population = Convert.ToInt32(reader["population"]);
            //s.GovernmentForm = Convert.ToString(reader["governmentform"]);

            return s;
        }

        public void UpdateStudentUser(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_UpdateStudentUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@summary", summary);
                    //TODO
                    cmd.Parameters.AddWithValue("@previousExperience", previousExperience);
                    cmd.Parameters.AddWithValue("@degree", degree);
                    cmd.Parameters.AddWithValue("@contactInfo", contactInfo);
                    cmd.Parameters.AddWithValue("@skills", skills);
                    cmd.Parameters.AddWithValue("@interests", interests);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public Student GetStudent(string username)
        {
            Student output = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetStudent, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Student();
                        output.Summary = Convert.ToString(reader["summary"]);

                        output.PreviousExperience = Convert.ToString(reader["previousExperience"]);
                        output.AcademicDegree = Convert.ToString(reader["degree"]);
                        output.ContantInfo = Convert.ToString(reader["contactInfo"]);
                        output.Skills = Convert.ToString(reader["skills"]);
                        output.Interests = Convert.ToString(reader["interests"]);
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
