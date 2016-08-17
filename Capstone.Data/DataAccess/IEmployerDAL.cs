using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;

namespace Capstone.Data.DataAccess
{
    public interface IEmployerDAL
    {
        Employer GetEmployer(string username);
        bool AddEmployerUser(string username, string firstName, string lastName, string company, string emailAdress, string location);
        //bool UpdateEmployer(string username);
        bool AddInterest(string username, string interest);
        bool DeleteInterest(string username, string interest);
    }
}
