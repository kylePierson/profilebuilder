using Capstone.Data.DataAccess;
using Capstone.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult NewsFeedByLanguage(string language)
        {
            // for simplisity assume language is c#
            language = "C#";
           List<Student> model = studentDAL.GetAllStudentsWithKnowLanguage(language);
           
            return View("StudentNewsFeed",model);

        }

        //maybe combine uploads into edit profile actionresult and view
        [HttpPost]
        public ActionResult Uploads(string username, IEnumerable<HttpPostedFileBase> files)
        {
            int iteration = 0;
            string[] fileNames = new string[] { username, username + "_Resume", username + "_CoverLetter" };

            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = fileNames[iteration];
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                }
                iteration++;
            }
            return RedirectToAction("Index");
        }
    }
}