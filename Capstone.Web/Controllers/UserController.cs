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

        public ActionResult LogIn()
        {
            //username and password view model to send to view
            LoginViewModel model = new LoginViewModel();
            return View("Login", model);
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            UserPassword model = 
            if (!ModelState.IsValid || )
            {
                
            }
            return View("Login");
            //verify credentials, get role title and redirect to proper controller
            //return RedirectToAction("Index", model.title, model);
        }
    }
}