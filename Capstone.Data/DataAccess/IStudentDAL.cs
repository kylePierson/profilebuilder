using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Data.Models;

namespace Capstone.Data.DataAccess
{
    public interface IStudentDAL
    {
        List<Student> GetAllStudents();
    }
}
