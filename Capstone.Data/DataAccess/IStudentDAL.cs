using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;
using System.Data.SqlClient;

namespace Capstone.Data.DataAccess
{
    public interface IStudentDAL
    {
        List<Student> GetAllStudents();
        bool AddStudentUser(string username, string firstName, string lastName, string cohort);
        bool UpdateStudentUser(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests);
        Student GetStudent(string username);
        HashSet<Student> GetAllStudentsWithKnowLanguage(string username);
        List<Student> GetAllStudentsWithKnowLanguageAndClass(string language, string studentClass);
        void AddProject(string username, Project project);
        List<Project> GetProjectList(string username);
        void UpdateInterest(string interest, int studentId, SqlConnection conn);
        void UpdateSkill(string skill, int studentId, SqlConnection conn);
        int GetStudentId(string username, SqlConnection conn);
        Student CreateStudentFromReader(SqlDataReader reader)
    }
}
