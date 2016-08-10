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
        void AddStudentUser(string username, string firstName, string lastName, string cohort);
        void UpdateStudentUser(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests);
        Student GetStudent(string username);
    }
}
