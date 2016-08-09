using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Capstone.Data.Models.Students> AllStudents { get; set; }



    }
}