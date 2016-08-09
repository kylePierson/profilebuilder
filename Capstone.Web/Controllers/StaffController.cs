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
        
        public StaffController(IStaffDAL staffDal, IUserPasswordDAL userPasswordDal)
        {
            this.staffDal = staffDal;
            this.userPasswordDal = userPasswordDal;
        }

        public ActionResult Index(string username)
        {
            Staff currentUser = staffDal.GetStaff(username);
            return View("Index", currentUser);
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
        public ActionResult CreateStaffUser(string username, string firstName, string lastName, string title)
        {
            
            if (!ModelState.IsValid)
            {
                return View("CreateStaffUser");
            };
            //add user to correct db's

            userPasswordDal.AddUser(username, "password" , "Staff");

            return RedirectToAction("Index");
        }

        public ActionResult CreateStudentUser()
        {
            return View("CreateStaffUser");
        }

        [HttpPost]
        public ActionResult CreateStudentUser(UserPassword user)
        {

            if (!ModelState.IsValid)
            {
                return View("CreateStaffUser");
            }
            user.RoleTitle = "Staff";

            //add user to correct db's

            //userPasswordDal.AddUser(user);

            return RedirectToAction("Index");
        }
        
    }
}