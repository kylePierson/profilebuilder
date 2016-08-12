using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.DataAccess
{
    public interface IUserPasswordDAL
    {
        bool ChangePassword(string username, string newPassword);
        UserPassword GetUser(string username, string password);
        UserPassword GetUser(string username);
        bool AddUser(string username, string password, string role);
    }
}
