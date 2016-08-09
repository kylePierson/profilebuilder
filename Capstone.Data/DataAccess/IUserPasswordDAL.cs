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
        UserPassword GetUser(string username, string password);
        void AddUser(UserPassword user);
    }
}
