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

            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            UserPassword model = userPasswordDal.GetUser(username, password);

            if (!ModelState.IsValid || model==null)
            {
                return View("LogIn");
            }

            return RedirectToAction("Index", model.RoleTitle, new { username = model.Username });
        }
    }
}