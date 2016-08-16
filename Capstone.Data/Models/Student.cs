using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        //public List<string>  PreviousExperience { get; set; } 
        //public List<string> AcademicDegree { get; set; }
        public string PreviousExperience { get; set; }
        public string AcademicDegree { get; set; }
        public string ContantInfo { get; set; }
        public string Skills { get; set; }
        public string Interests { get; set; }
       public List<string> Project { get; set; }
        //public List<string> PreviousExperience { get; set; }
        //public List<string> AcademicDegree { get; set; }
    }
}
