using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.Models
{
    public class EmployerStudent
    {
        //employer 
        public int EmployerId { get; set; }
        public string EmployerUsername { get; set; }
        public string EmployerCompanyName { get; set; }
        public string EmployerContactFirstName { get; set; }
        public string EmployerContactLastName { get; set; }
        public string EmployerContactInfo { get; set; }
        public string EmployerAddress { get; set; }
        public List<string> EmployerLanguagesInterested { get; set; }

        //student
        public int StudentId { get; set; }
        public string StudentUsername { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentClass { get; set; }
        public string StudentSummary { get; set; }
        public string StudentPreviousExperience { get; set; }
        public string StudentAcademicDegree { get; set; }
        public string StudentContantInfo { get; set; }
        public string StudentSkills { get; set; }
        public string StudentInterests { get; set; }
        //later we will make the following properties 'List'
        
        //public List<string> PreviousExperience { get; set; }
        //public List<string> AcademicDegree { get; set; }
        //public List<string> PreviousExperience { get; set; }
        //public List<string> AcademicDegree { get; set; }
    }
}
