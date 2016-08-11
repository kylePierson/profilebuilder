using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Data.Models;
using Capstone.Data.DataAccess;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentDAL studentSqlDAl;
        public HomeController(IStudentDAL studentDal)
        {
            this.studentSqlDAl =  studentDal;
        }


        // GET: Home
        public ActionResult Index()
        {
            List<Student> model = new List<Student>();
            model = studentSqlDAl.GetAllStudents();
                
            return View("Index", model);
        }

        
    }
}