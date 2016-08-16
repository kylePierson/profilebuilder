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
        //****DO NOT DELETE SQL_AddStudentUser QUERY********
        private const string SQL_AddStudentUser = @"INSERT INTO student (username, firstname, lastname, class) 
                                                    VALUES (@username, @firstname, @lastname, @class);";
        //****DO NOT DELETE SQL_AddStudentUser QUERY********

        private const string SQL_UpdateStudentUser = @"UPDATE student 
                                                        SET summary=@summary, previousexperience=@previousexperience, degree=@degree, contactinfo=@contactInfo, skill=@skills, interests=@interests 
                                                        where username = @username";
        private const string SQL_GetAllStudents = "";

        private const string SQL_GetSkill = @"SELECT * FROM softskills WHERE skill=@skill";

        private const string SQL_AddSkill = @"INSERT INTO softskills VALUES(@skill);";

        private const string SQL_AddSkillToSkillStudent = @"INSERT INTO student_softskills VALUES(@skillid, @studentid);";

        private const string SQL_UpdateSkills = @"Update";

        //Edit the next query VVV
        private const string SQL_GetStudent = @"SELECT student.student_id, student.firstname,student.lastname, student.username, student.summary, 
                                              student.previousexperience, student.class, student.contactinfo, academic.degree, softskills.skill, interests.interest
                                              FROM student
                                              INNER JOIN academic on student.student_id = academic.student_id
                                              INNER JOIN student_softskills ON student.student_id = student_softskills.student_id
                                              INNER JOIN softskills ON student_softskills.softskill_id = softskills.softskill_id
                                              INNER JOIN student_interests ON student.student_id = student_interests.student_id
                                              INNER JOIN interests ON student_interests.interest_id = interests.interest_id
                                              WHERE username = @username;";

        private const string SQL_GetStudentTest = @"SELECT * FROM student WHERE username = @username;";


        private const string SQL_CreateStudentFromReader = "SELECT * FROM student;";
        private string SQL_getstudentList_KnownLanguage = @"select student.firstname, student.lastname, student.class
                        from student
                        inner join student_language on student.student_id = student_language.student_id
                        inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
                        where programming_language.name = @language";


        private const string SQL_GetAllStudent_Language_Class = @"SELECT student.firstname , student.lastname
                                from student
                                inner join student_language on student_language.student_id = student.student_id
                                inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
                                where programming_language.name = @language AND student.class= @studentClass;";

        public StudentSqlDAL()
            : this(ConfigurationManager.ConnectionStrings["CapstoneDatabaseConnection"].ConnectionString)
        {
        }

        //Constructor
        public StudentSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        //*************************************************
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

            }

            return rowsAffected > 0;
        }
        //***************************************************


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
            // s.PreviousExperience = Convert.ToString(reader["previousexperience"]);
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
                    cmd.Parameters.AddWithValue("@previousexperience", previousExperience);
                    cmd.Parameters.AddWithValue("@degree", degree);
                    cmd.Parameters.AddWithValue("@contactInfo", contactInfo);

                    cmd.Parameters.AddWithValue("@interests", interests);

                    cmd.ExecuteNonQuery();

                    //UpdateSkill(skills, GetStudent(username).StudentId, conn);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return updateIsDone;
        }

        public List<Student> StudentsWithSpecificProgramingLanguage(string language)
        {
            // for simplisity assume language is c#
            language = "C#";

            List<Student> output = new List<Student>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_getstudentList_KnownLanguage, conn);
                    cmd.Parameters.AddWithValue("@language", language);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student newStudent = new Student();
                        newStudent.FirstName = Convert.ToString(reader["firstName"]);
                        newStudent.LastName = Convert.ToString(reader["lastName"]);
                        newStudent.Class = Convert.ToString(reader["class"]);

                        output.Add(newStudent);
                    }
                }
                return output;
            }
            catch (Exception ex)
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
                    SqlCommand cmd = new SqlCommand(SQL_GetStudentTest, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Student();
                        output.FirstName = Convert.ToString(reader["firstname"]);
                        output.LastName = Convert.ToString(reader["lastname"]);
                        output.Username = Convert.ToString(reader["username"]);
                        output.Summary = Convert.ToString(reader["summary"]);
                        output.StudentId = Convert.ToInt32(reader["student_id"]);

                        output.PreviousExperience = Convert.ToString(reader["previousexperience"]);
                        //output.AcademicDegree = Convert.ToString(reader["degree"]);
                        output.ContantInfo = Convert.ToString(reader["contactInfo"]);
                        //output.Skills = Convert.ToString(reader["skills"]);
                        //output.Interests = Convert.ToString(reader["interests"]);



                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public HashSet<Student> GetAllStudentsWithKnowLanguage(string username)
        {
            string SQL_GetAllStudent_Language = @"SELECT student.firstname , student.lastname
                                from student
                                inner join student_language on student_language.student_id = student.student_id
                                inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
                                where ";

            HashSet<Student> output = new HashSet<Student>();
            List<string> languages = new List<string>();

            string query = @"select programming_language.name
                        from programming_language
                        inner join employer_language on employer_language.programminglanguage_id = programming_language.programminglanguage_id
                        inner join employer on employer.employer_id = employer_language.employer_id
                        where employer.username =@username";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string language = Convert.ToString(reader["name"]);
                    languages.Add(language);
                }
            }

            for (int i = 0; i < languages.Count; i++)
            {
                if (i == 0)
                    SQL_GetAllStudent_Language = String.Concat(SQL_GetAllStudent_Language, "programming_language.name = '", languages[i], "' ");
                else
                    SQL_GetAllStudent_Language = String.Concat(SQL_GetAllStudent_Language, " OR programming_language.name = '", languages[i], "' ");

            }
            SQL_GetAllStudent_Language = String.Concat(SQL_GetAllStudent_Language, ";");
            try
            {
                //string SQL_GetAllStudent_Language = @"SELECT student.firstname , student.lastname, student.class
                //                from student
                //                inner join student_language on student_language.student_id = student.student_id
                //                inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
                //               where programming_language.name = 'C#' ;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllStudent_Language, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student newStudent = new Student();

                        newStudent.FirstName = Convert.ToString(reader["firstname"]);
                        newStudent.LastName = Convert.ToString(reader["lastname"]);
                        //newStudent.Class = Convert.ToString(reader["class"]);
                        output.Add(newStudent);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;

        }

        public List<Student> GetAllStudentsWithKnowLanguageAndClass(string language, string studentClass)
        {
            List<Student> output = new List<Student>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllStudent_Language_Class, conn);
                    cmd.Parameters.AddWithValue("@language", language);
                    cmd.Parameters.AddWithValue("@StudentClass", studentClass);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student newStudent = new Student();

                        newStudent.FirstName = Convert.ToString(reader["firstname"]);
                        newStudent.LastName = Convert.ToString(reader["lastname"]);

                        output.Add(newStudent);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;

        }

        //private void UpdateSkill(string skill, int studentId, SqlConnection conn)
        //{
        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand(SQL_GetSkill, conn);
        //        cmd.Parameters.AddWithValue("@skill", skill);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        Skill s = null;
        //        int skillId;

        //        while (reader.Read())
        //        {
        //            s = new Skill();
        //            s.Id = Convert.ToInt32(reader["softskill_id"]);
        //            s.Name = Convert.ToString(reader["skill"]);

        //        }

        //        if (s == null)
        //        {
        //            cmd = new SqlCommand(SQL_AddSkill, conn);
        //            cmd.Parameters.AddWithValue("@skill", skill);

        //            skillId = Convert.ToInt32(cmd.ExecuteScalar());

        //            cmd = new SqlCommand(SQL_AddSkillToSkillStudent, conn);
        //            cmd.Parameters.AddWithValue("@skillid", skillId);
        //            cmd.Parameters.AddWithValue("@studenid", studentId);

        //            cmd.ExecuteNonQuery();
        //        }
        //        else
        //        {
        //            cmd = new SqlCommand(SQL_AddSkillToSkillStudent, conn);
        //            cmd.Parameters.AddWithValue("@skillid", s.Id);
        //            cmd.Parameters.AddWithValue("@studenid", studentId);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
