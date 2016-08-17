using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using Capstone.Web.Filters;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    [ProfileBuilderAuthorizationFilter]
    public class StaffController : ProfileBuilderController
    {
        IStaffDAL staffDal;
        IUserPasswordDAL userPasswordDal;
        IStudentDAL studentDal;
        IEmployerDAL employerDal;

        public StaffController(IStaffDAL staffDal, IUserPasswordDAL userPasswordDal, IStudentDAL studentDal, IEmployerDAL employerDal)
            : base(userPasswordDal)
        {
            this.staffDal = staffDal;
            this.userPasswordDal = userPasswordDal;
            this.studentDal = studentDal;
            this.employerDal = employerDal;
        }

        [ProfileBuilderAuthorizationFilter]
        public ActionResult Index(string username)
        {
            Staff currentUser = staffDal.GetStaff(username);
            return View("Index", currentUser);
        }

        public ActionResult CreateStaffUser()
        {
            return View("CreateStaffUser");
        }

        [HttpPost]
        public ActionResult CreateStaffUser(string currentUsername, string newUsername, string firstName, string lastName, string title, string emailAddress)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateStaffUser");
            };
            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(newUsername, "password", "Staff");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool staff = staffDal.AddStaffUser(newUsername, firstName, lastName, title);
            if (!staff)
            {
                return View("Fail");
            }

            SendEmail(emailAddress, firstName, newUsername, "Staff");
            return RedirectToAction("Success", new { username = currentUsername });
        }

        public ActionResult CreateStudentUser()
        {
            return View("CreateStudentUser");
        }

        [HttpPost]
        public ActionResult CreateStudentUser(string currentUsername, string newUsername, string firstname, string lastname, string cohort, string emailAddress)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateStudentUser");
            }

            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(newUsername, "password", "Student");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool student = studentDal.AddStudentUser(newUsername, firstname, lastname, cohort, emailAddress);
            if (!student)
            {
                return View("Fail");
            }

            SendEmail(emailAddress, firstname, newUsername, "Student");
            return RedirectToAction("Success", new { username = base.CurrentUser });
        }

        public ActionResult CreateEmployerUser()
        {
            return View("CreateEmployerUser");
        }

        [HttpPost]
        public ActionResult CreateEmployerUser(string currentUsername, string newUsername, string firstname, string lastname, string company, string location, string emailAddress)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateEmployerUser");
            }

            //add user to correct db's

            bool userPassword = userPasswordDal.AddUser(newUsername, "password", "Employer");
            if (!userPassword)
            {
                return View("Fail");
            }
            bool employer = employerDal.AddEmployerUser(newUsername, firstname, lastname, company, emailAddress, location);
            if (!employer)
            {
                return View("Fail");
            }

            SendEmail(emailAddress, firstname, newUsername, "Employer");
            return RedirectToAction("Success", new { username = currentUsername });

        }

        public ActionResult Success(string username)
        {
            UserPassword model = userPasswordDal.GetUser(username);
            return View("Success", model);
        }

        private void SendEmail(string emailAddress, string firstName, string username, string role)
        {
            dynamic email = new Email(role + "EmailPage");
            email.To = emailAddress;
            email.FirstName = firstName;
            email.Username = username;
            email.Send();
        }
    }
}