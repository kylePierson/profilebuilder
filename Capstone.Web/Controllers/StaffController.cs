using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class StaffController : Controller
    {
        IStaffDAL staffDal;
        IUserPasswordDAL userPasswordDal;
        IStudentDAL studentDal;
        IEmployerDAL employerDal;

        public StaffController(IStaffDAL staffDal, IUserPasswordDAL userPasswordDal, IStudentDAL studentDal, IEmployerDAL employerDal)
        {
            this.staffDal = staffDal;
            this.userPasswordDal = userPasswordDal;
            this.studentDal = studentDal;
            this.employerDal = employerDal;
        }

        public ActionResult Index(string username)
        {
            Staff currentUser = staffDal.GetStaff(username);
            return View("Index", currentUser);
        }

        public ActionResult CreateStaffUser(string username)
        {
            return View("CreateStaffUser", username);
        }

        [HttpPost]
        public ActionResult CreateStaffUser(string currentUsername, string username, string firstName, string lastName, string title)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateStaffUser");
            };
            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(username, "password", "Staff");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool staff = staffDal.AddStaffUser(username, firstName, lastName, title);
            if (!staff)
            {
                return View("Fail");
            }


            return RedirectToAction("Success", new { currentUser = currentUsername });
        }

        public ActionResult CreateStudentUser()
        {
            return View("CreateStudentUser");
        }

        [HttpPost]
        public ActionResult CreateStudentUser(string username, string firstname, string lastname, string cohort)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateStudentUser");
            }

            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(username, "password", "Student");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool student = studentDal.AddStudentUser(username, firstname, lastname, cohort);
            if (!student)
            {
                return View("Fail");
            }

            return RedirectToAction("Index");
        }

        public ActionResult CreateEmployerUser()
        {
            return View("CreateEmployerUser");
        }

        [HttpPost]
        public ActionResult CreateEmployerUser(string username, string firstname, string lastname, string company, string programingLanguage)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateEmployerUser");
            }

            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(username, "password", "Employer");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool employer = employerDal.AddEmployerUser(username, firstname, lastname, company, programingLanguage);
            if (!employer)
            {
                return View("Fail");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Success(string currentUser)
        {
            UserPassword user = userPasswordDal.GetUser(currentUser);
            return View("Success", user);
        }
    }
}