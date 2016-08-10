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
        private const string SQL_AddStudentUser = @"INSERT INTO student (username, firstname, lastname, class) 
                                                    VALUES (@username, @firstname, @lastname, @class);";

        private const string SQL_UpdateStudentUser = @"UPDATE student 
                                                        SET summary=@summary, previousexperience=@previousexperience, degree=@degree, contactinfo=@contactInfo, skill=@skills, interests=@interests 
                                                        where username = @username";
        private const string SQL_GetAllStudents = "";
        private const string SQL_GetStudent = "SELECT * FROM student WHERE @username=username;";
        private const string SQL_CreateStudentFromReader = "SELECT * FROM student;";
        public StudentSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public StudentSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public bool AddStudentUser(string username, string firstName, string lastName, string cohort)
        {
            int rowsAffected = 0;
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

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return rowsAffected > 0;
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
                    cmd.CommandText = SQL_CreateStudentFromReader;
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student s = CreateStudentFromReader(reader);
                        //get other info on student from other tables
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
            s.FirstName = Convert.ToString(reader["firstname"]);
            s.LastName = Convert.ToString(reader["lastname"]);
            s.Username = Convert.ToString(reader["username"]);
            s.StudentId = Convert.ToInt32(reader["student_id"]);
            s.Class = Convert.ToString(reader["class"]);
            s.Summary = Convert.ToString(reader["summary"]);
            s.PreviousExperience = Convert.ToString(reader["previousexperience"]);
            s.ContantInfo = Convert.ToString(reader["contactinfo"]);
            return s;
        }

        public bool UpdateStudentUser(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests)
        {
            var updateIsDone = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_UpdateStudentUser, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@summary", summary);
                    //TODO
                    cmd.Parameters.AddWithValue("@previousexperience", previousExperience);
                    cmd.Parameters.AddWithValue("@degree", degree);
                    cmd.Parameters.AddWithValue("@contactInfo", contactInfo);
                    cmd.Parameters.AddWithValue("@skills", skills);
                    cmd.Parameters.AddWithValue("@interests", interests);

                    cmd.ExecuteNonQuery();
                    updateIsDone = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return updateIsDone;
        }

        public Student GetStudent(string username)
        {
            username = "siminN";
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

                        output.PreviousExperience = Convert.ToString(reader["previousexperience"]);
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
