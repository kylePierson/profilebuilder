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
        private const string SQL_AddStudentUser = @"INSERT INTO student (username, firstname, lastname, class, contactinfo) 
                                                    VALUES (@username, @firstname, @lastname, @class, @contactinfo);";
        //****DO NOT DELETE SQL_AddStudentUser QUERY********

        private const string SQL_UpdateStudentUser = @"UPDATE student 
                                                        SET summary=@summary, previousexperience=@previousexperience, degree=@degree, contactinfo=@contactInfo, skill=@skills, interests=@interests 
                                                        where username = @username";
        private const string SQL_GetAllStudents = "";

        private const string SQL_GetSkill = @"SELECT * FROM softskills WHERE skill=@skill";

        private const string SQL_AddSkill = @"INSERT INTO softskills VALUES(@skill);";

        private const string SQL_AddSkillToSkillStudent = @"INSERT INTO student_softskills VALUES(@skillid, @studentid);";


        //Edit the next query VVV

        private const string SQL_GetStudent = @"SELECT *
                                                FROM student
                                                WHERE username = @username;";

        private const string SQL_GetStudentTest = @"SELECT * FROM student WHERE username = @username;";


        private const string SQL_CreateStudentFromReader = "SELECT * FROM student;";
        private string SQL_getstudentList_KnownLanguage = @"select student.firstname, student.lastname, student.class
                        from student
                        inner join student_language on student.student_id = student_language.student_id
                        inner join programming_language on programming_language.programminglanguage_id = student_language.programminglanguage_id
                        where programming_language.name = @language";


        private const string SQL_GetAllStudent_Language_Class = @"SELECT student.firstname , student.lastname , student.username
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

        private int GetStudentId(string username, SqlConnection conn)
        {
            int output = 0;
            string SQL_GetStudentId = @"SELECT student_id FROM student WHERE username=@username;";
            try
            {


                SqlCommand c = new SqlCommand(SQL_GetStudentId, conn);
                c.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    output = Convert.ToInt32(reader["student_id"]);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        //*************************************************
        public bool AddStudentUser(string username, string firstName, string lastName, string cohort, string emailAddress)
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
                    cmd.Parameters.AddWithValue("@contactinfo", emailAddress);

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
            s.ContactInfo = Convert.ToString(reader["contactinfo"]);
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

                    cmd.ExecuteNonQuery();

                    UpdateSkill(skills, GetStudent(username).StudentId, conn);
                    UpdateInterest(interests, GetStudent(username).StudentId, conn);

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
                    SqlCommand cmd = new SqlCommand(SQL_GetStudent, conn);
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
                        output.LinkedIn = Convert.ToString(reader["linkedin"]);                  
                        output.PreviousExperience = Convert.ToString(reader["previousexperience"]);
                        output.AcademicDegree = Convert.ToString(reader["acedemicdegree"]);
                        output.ContactInfo = Convert.ToString(reader["contactInfo"]);



                    }
                    reader.Close();
                    output.InterestList = GetInterestList(username, conn);
                    output.SkillList = GetSkillList(username, conn);
                    output.ProjectList = GetProjectList(username, conn);
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
            string SQL_GetAllStudent_Language = @"select distinct student.firstname, student.lastname from 
                                    employer 
                                    inner join employer_language 
                                    on employer.employer_id = employer_language.employer_id
                                    inner join student_language  
                                    on student_language.programminglanguage_id = employer_language.programminglanguage_id
                                    inner join student  on
                                    student.student_id = student_language.student_id
                                    where employer.username = @username; ";

            HashSet<Student> output = new HashSet<Student>();

          
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllStudent_Language, conn);
                    cmd.Parameters.AddWithValue("@username", username);
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

                        //newStudent.Username = Convert.ToString(reader["uername"]);


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


        private void UpdateSkill(string skill, int studentId, SqlConnection conn)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(SQL_GetSkill, conn);
                cmd.Parameters.AddWithValue("@skill", skill);

                SqlDataReader reader = cmd.ExecuteReader();

                Skill s = null;
                int skillId;

                while (reader.Read())
                {
                    s = new Skill();
                    s.Id = Convert.ToInt32(reader["softskill_id"]);
                    s.Name = Convert.ToString(reader["skill"]);

                }

                if (s == null)
                {
                    cmd = new SqlCommand(SQL_AddSkill, conn);
                    cmd.Parameters.AddWithValue("@skill", skill);

                    skillId = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand(SQL_AddSkillToSkillStudent, conn);
                    cmd.Parameters.AddWithValue("@skillid", skillId);
                    cmd.Parameters.AddWithValue("@studentid", studentId);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand(SQL_AddSkillToSkillStudent, conn);
                    cmd.Parameters.AddWithValue("@skillid", s.Id);
                    cmd.Parameters.AddWithValue("@studentid", studentId);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void UpdateInterest(string interest, int studentId, SqlConnection conn)
        {
            string SQL_GetInterest = @"SELECT * FROM softskills WHERE interest=@interest";

            string SQL_AddInterest = @"INSERT INTO softskills VALUES(@interest);";

            string SQL_AddInterestToInterestStudent = @"INSERT INTO student_softskills VALUES(@interestid, @studentid);";

            try
            {

                SqlCommand cmd = new SqlCommand(SQL_GetInterest, conn);
                cmd.Parameters.AddWithValue("@interest", interest);

                SqlDataReader reader = cmd.ExecuteReader();

                Interest s = null;
                int interestId;

                while (reader.Read())
                {
                    s = new Interest();
                    s.Id = Convert.ToInt32(reader["interest_id"]);
                    s.Name = Convert.ToString(reader["interest"]);

                }

                if (s == null)
                {
                    cmd = new SqlCommand(SQL_AddInterest, conn);
                    cmd.Parameters.AddWithValue("@interest", interest);

                    interestId = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand(SQL_AddSkillToSkillStudent, conn);
                    cmd.Parameters.AddWithValue("@interestid", interestId);
                    cmd.Parameters.AddWithValue("@studentid", studentId);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand(SQL_AddInterestToInterestStudent, conn);
                    cmd.Parameters.AddWithValue("@interestid", s.Id);
                    cmd.Parameters.AddWithValue("@studentid", studentId);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddProject(string username, Project project)
        {
            string SQL_AddProject = @"INSERT INTO project VALUES (@title,@summary,@studentid);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    project.StudentId = GetStudentId(username, conn);
                    SqlCommand cmd = new SqlCommand(SQL_AddProject, conn);
                    cmd.Parameters.AddWithValue("@title", project.Title);
                    cmd.Parameters.AddWithValue("@summary", project.Summary);
                    cmd.Parameters.AddWithValue("@studentid", project.StudentId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<Project> GetProjectList(string username, SqlConnection conn)
        {
            List<Project> output = new List<Project>();

            string SQL_GetProjects = @"SELECT * FROM project WHERE student_id=@studentid;";

            try
            {


                SqlCommand cmd = new SqlCommand(SQL_GetProjects, conn);
                cmd.Parameters.AddWithValue("@studentid", GetStudentId(username, conn));


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Project p = new Project();

                    p.Title = Convert.ToString(reader["title"]);
                    p.Summary = Convert.ToString(reader["summary"]);

                    output.Add(p);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;

        }

        private List<string> GetSkillList(string username, SqlConnection conn)
        {
            List<string> output = new List<string>();

            string SQL_GetProjects = @"SELECT softskills.skill FROM softskills, student_softskills WHERE softskills.softskill_id= student_softskills.softskill_id AND student_softskills.student_id=@studentid;";

            try
            {

                SqlCommand cmd = new SqlCommand(SQL_GetProjects, conn);
                cmd.Parameters.AddWithValue("@studentid", GetStudentId(username, conn));


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    string skill = Convert.ToString(reader["skill"]);

                    output.Add(skill);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

        private List<string> GetInterestList(string username, SqlConnection conn)
        {
            List<string> output = new List<string>();

            string SQL_GetProjects = @"SELECT interests.interest FROM interests, student_interests WHERE interests.interest_id= student_interests.interest_id AND student_interests.student_id=@studentid;";

            try
            {

                SqlCommand cmd = new SqlCommand(SQL_GetProjects, conn);
                cmd.Parameters.AddWithValue("@studentid", GetStudentId(username, conn));


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    string skill = Convert.ToString(reader["interest"]);

                    output.Add(skill);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }
    }
}
