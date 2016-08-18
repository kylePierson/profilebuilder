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
        bool AddStudentUser(string username, string firstName, string lastName, string cohort, string emailAddress);
        bool UpdateStudentUser(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests);
        Student GetStudent(string username);
        HashSet<Student> GetAllStudentsWithKnowLanguage(string username);
        List<Student> GetAllStudentsWithKnowLanguageAndClass(string language, string studentClass);
        void AddProject(string username, Project project);

        //update student info from dash board
        void UpdateStudentContactInfo(string username, string contactInfo);
        bool UpdateStudentSummary(string username, string summary);
        bool UpdateStudentAcademicDegree(string username, string degree);
        bool UpdateStudentPreviousExperience(string username, string experience);
        void AddStudentSkill(string username, string skill);
        void DeleteStudentSkill(string username, string skill);
        void AddStudentInterest(string username, string interest);
        void DeleteStudentInterest(string username, string interest);

        //List<Project> GetProjectList(string username);
        //void UpdateInterest(string interest, int studentId, SqlConnection conn);
        //void UpdateSkill(string skill, int studentId, SqlConnection conn);
        //int GetStudentId(string username, SqlConnection conn);
        //Student CreateStudentFromReader(SqlDataReader reader);

    }
}
