using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }      
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string Summary { get; set; }
        public List<string>  PreviousExperience { get; set; } 
        public List<string> AcademicDegree { get; set; }
        public string ContantInfo { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Interests { get; set; }

    }
}
