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
        
        public StaffController(IStaffDAL staffDal)
        {
            this.staffDal = staffDal;
        }

        public ActionResult Index(string username)
        {
            Staff currentUser = staffDal.GetStaff(username);
            return View("Index");
        }

        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        public ActionResult CreateStaffUser()
        {
            return View("CreateStaffUser");
        }

        [HttpPost]
        public ActionResult CreateStaffUser(UserPassword user)
        {
            
            if (!ModelState.IsValid)
            {
                return View("CreateStaffUser");
            }

            //add user to correct db's

            return RedirectToAction("Index");
        }
    }
}