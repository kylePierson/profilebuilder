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
            string model = username;
            return View("UpdateProfile");
        }

        [HttpPost]
        public ActionResult UpdateProfile(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProfile");
            }

            UploadFiles(username, files);

            bool updateSuccess = studentDAL.UpdateStudentUser(username, summary, previousExperience, degree, contactInfo, skills, interests);
            if (updateSuccess)
            {
                return View("Success");
            }
            else
            {
                return View("Fail");
            }
        }

        public ActionResult NewsFeedByLanguage(string username)
        {

            HashSet<Student> model = studentDAL.GetAllStudentsWithKnowLanguage(username);

            return View("StudentNewsFeed", model);

        }

        //maybe combine uploads into edit profile actionresult and view

        private void UploadFiles(string username, IEnumerable<HttpPostedFileBase> files)
        {
            Student s = studentDAL.GetStudent(username);
            string fullName = s.FirstName.ToLower() + s.LastName.ToLower();
            int iteration = 0;
            string[] fileNames = new string[] { fullName, fullName + "_Resume", fullName + "_CoverLetter" };

            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    string[] segments = file.FileName.Split('.');
                    string fileExt = segments[segments.Length - 1];
                    var fileName = fileNames[iteration]+"."+fileExt;
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                    file.SaveAs(path);
                }
                iteration++;
            }
        }


        //drop down list for employer to select language to search students

        public ActionResult SearchStudentsByLanguage()
        {
            List<SelectListItem> languagesDropDown = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "C#" },
                new SelectListItem() { Text = "Java" },
                new SelectListItem() { Text = "CSS" },
                new SelectListItem() { Text = "HTML" },
                new SelectListItem() { Text = "JavaScript" },
                new SelectListItem() { Text = "JQuery" },
                new SelectListItem() { Text = "SQL" }
            };
            List<SelectListItem> classDropDown = new List<SelectListItem>()
            {
                new SelectListItem() { Text = ".NET" },
                new SelectListItem() { Text = "JAVA" }               
            };
            ViewBag.languagesDropDownList = languagesDropDown;
            ViewBag.classDropDownList = classDropDown;

            
            return View("SearchStudents");
        }
        [HttpPost]
        public ActionResult SearchStudentsByLanguage(string language, string studentClass)
        {
            List<Student> model = studentDAL.GetAllStudentsWithKnowLanguageAndClass(language, studentClass);

            return View("StudentSearchResult", model);
        }
    }
}