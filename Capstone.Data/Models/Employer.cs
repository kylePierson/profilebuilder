using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string Username { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }
        public List<string> Programming_language { get; set; }
    }
}
