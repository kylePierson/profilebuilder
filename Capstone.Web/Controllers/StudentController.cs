using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class StudentController : Controller
    {
        IStudentDAL studentDAL;
        IUserPasswordDAL userPasswordDAL;

        public StudentController(IStudentDAL studentDAL, IUserPasswordDAL userPasswordDAL)
        {
            this.studentDAL = studentDAL;
            this.userPasswordDAL = userPasswordDAL;
        }

        // GET: Student
        public ActionResult Index(string username)
        {
            Student currentUser = studentDAL.GetStudent(username);
            return View("Index", currentUser);
        }
        
        public ActionResult UpdateProfile(string username)
        {
            return View("UpdateProfile", username);
        }

        [HttpPost]
        public ActionResult UpdateProfile(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProfile");
            }

            bool updateSuccess = studentDAL.UpdateStudentUser(username, summary, previousExperience, degree, contactInfo, skills, interests);
            if (updateSuccess)
            {
                return RedirectToAction("Success", "Staff");
            }
            else
            {
                return RedirectToAction("Fail", "Staff");
            }
        }

    }
}