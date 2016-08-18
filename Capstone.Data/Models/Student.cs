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
        public string PreviousExperience { get; set; }
        public string AcademicDegree { get; set; }
        public string ContactInfo { get; set; }
        public List<string> InterestList { get; set; }
        public List<string> SkillList { get; set; }
        public List<Project> ProjectList { get; set; }
        public string LinkedIn { get; set; }
        public string ElevatorPitch { get; set; }

    }
}
