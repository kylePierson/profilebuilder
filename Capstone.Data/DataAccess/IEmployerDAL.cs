using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.DataAccess
{
    public interface IEmployerDAL
    {
        bool AddEmployerUser(string username, string firstName, string lastName, string company, string programingLanguage);
    }
}
