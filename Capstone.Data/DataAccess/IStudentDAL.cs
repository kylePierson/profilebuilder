using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;

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
    }
}
