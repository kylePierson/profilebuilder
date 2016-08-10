using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Data.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Student> model = new List<Student>();
            // test data
            //model.Add(new Student
            //{
            //    FirstName = "Laak Posht",
            //    LastName = "Nickelsen"
            //});
            return View("Index", model);
        }

        
    }
}