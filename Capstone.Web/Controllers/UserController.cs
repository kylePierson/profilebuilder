using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using Capstone.Web.Filters;
using Capstone.Web.Models;
using Critter.Web.Models;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class UserController : ProfileBuilderController
    {
        private readonly IUserPasswordDAL userPasswordDal;
        private readonly IStudentDAL studentDal;
        private readonly IEmployerDAL employerDal;

        public UserController(IUserPasswordDAL userPasswordDal, IStudentDAL studentDal, EmployerSqlDAL employerDal)
            : base(userPasswordDal)
        {
            this.userPasswordDal = userPasswordDal;
            this.studentDal = studentDal;
            this.employerDal = employerDal;
        }

        public ActionResult LogIn()
        {
            //username and password view model to send to view
            LoginViewModel model = new LoginViewModel();
            return View("LogIn", model);
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                UserPassword model = userPasswordDal.GetUser(login.Username);

                if (model == null)
                {
                    ModelState.AddModelError("invalid username", "The username or password provided is invalid");
                    return View("LogIn", login);
                }
                if (model.Password != login.Password)
                {
                    ModelState.AddModelError("invalid pwd", "The username or password provided is invalid");
                    return View("LogIn", login);
                }

                //happy path
                base.LogUserIn(model.Username);

                return RedirectToAction("Index", model.RoleTitle, new { username = model.Username });
            }
            else
            {
                return View("LogIn", login);
            }
        }

        [ProfileBuilderAuthorizationFilter]
        public ActionResult ChangePassword(string username)
        {
            var model = new ChangePasswordViewModel();
            model.Username = username;
            return View("ChangePassword", model);
        }

        [HttpPost]
        [ProfileBuilderAuthorizationFilter]
        public ActionResult ChangePassword(string username, ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePassword", model);
            }

            var user = userPasswordDal.GetUser(username);

            // User is not null and password is not equal to model.current password
            if (user?.Password != model.CurrentPassword)
            {
                ModelState.AddModelError("incorrect password", "Supplied incorrect current password");
                return View("ChangePassword", model);
            }

            userPasswordDal.ChangePassword(username, model.NewPassword);
            //TODO: Come back and fix change password

            return RedirectToAction("Dashboard", "Messages", new { username = base.CurrentUser });
        }

        public ActionResult Logout()
        {
            base.LogUserOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {           
            List<SelectListItem> roleDropDown = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Student" },
                new SelectListItem() { Text = "Employer" },
            };

            ViewBag.RoleDropDownList = roleDropDown;
            return View("ForgotPassword");
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string role)
        {
            UserPassword user = userPasswordDal.GetUser(username);
            if (user == null)
            {
                ModelState.AddModelError("invalid username", "A registered username is required");
            }

            if (user.RoleTitle == "Employer")
            {
                string contactEmail = employerDal.GetEmployer(username).ContactInfo;
                string newPassword = userPasswordDal.ResetPassword(username);
                SendEmail(contactEmail, username, newPassword);
            }
            else if (user.RoleTitle == "Student")
            {
                string contactEmail = studentDal.GetStudent(username).ContactInfo;
                string newPassword = userPasswordDal.ResetPassword(username);
                SendEmail(contactEmail, username, newPassword);               
            }
            return RedirectToAction("Index", "Home");
        }

        private void SendEmail(string emailAddress, string username, string newPassword)
        {
            dynamic email = new Email("ForgotPasswordEmailPage");
            email.To = emailAddress;
            email.Username = username;
            email.NewPassword = newPassword;
            email.Send();
        }

    }
}