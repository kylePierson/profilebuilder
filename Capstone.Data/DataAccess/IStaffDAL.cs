using Capstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.DataAccess
{
    public interface IStaffDAL
    {
        Staff GetStaff(string username);
        bool AddStaffUser(string username, string firstName, string lastName, string title);
    }
}
