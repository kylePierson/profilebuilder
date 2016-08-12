using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Data.Models;
using Capstone.Data.DataAccess;

namespace Capstone.Web.Controllers
{
    public class EmployerController : Controller
    {
        IEmployerDAL employerDAL;

        public EmployerController(IEmployerDAL employerDal)
        {    
            this.employerDAL = employerDal;
        }
        // GET: Employer
        public ActionResult Index(string username)
        {
            //assign a username for test
            username = "user";

            Employer model = employerDAL.GetEmployer(username);

            return View("Index",model);
        }

        public ActionResult DeleteSkillInterested(string skill)
        {
            return View();
        }

        public ActionResult AddSkillInterested()
        {
            return View();
        }

    }
}