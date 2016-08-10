using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserPasswordDAL userPasswordDal;

        public UserController(IUserPasswordDAL userPasswordDal)
        {
            this.userPasswordDal = userPasswordDal;
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
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }
            UserPassword model = userPasswordDal.GetUser(login.Username, login.Password);

            return RedirectToAction("Index", model.RoleTitle, new {username= model.Username});
        }
    }
}