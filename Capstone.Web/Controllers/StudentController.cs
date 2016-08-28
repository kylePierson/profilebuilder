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
        public ActionResult UpdateProfile(string username, string summary, string previousExperience, string degree, string contactInfo, string skills, string interests, HttpPostedFileBase photo, HttpPostedFileBase resume, HttpPostedFileBase coverLetter)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateProfile");
            }

            UploadFiles(username, photo, resume, coverLetter);

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

        public ActionResult UploadFiles(string username, HttpPostedFileBase photo, HttpPostedFileBase resume, HttpPostedFileBase coverLetter)
        {
            Student s = studentDAL.GetStudent(username);
            string fullName = s.FirstName.ToLower() + s.LastName.ToLower();

            string[] fileNames = new string[] { fullName, fullName + "_Resume", fullName + "_CoverLetter" };

            if (photo != null && photo.ContentLength > 0)
            {
                string[] segments = photo.FileName.Split('.');
                var fileName = fileNames[0] + ".jpg";
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                photo.SaveAs(path);
            }
            if (resume != null && resume.ContentLength > 0)
            {
                string[] segments = resume.FileName.Split('.');
                string fileExt = segments[segments.Length - 1];
                var fileName = fileNames[1] + "." + fileExt;
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                resume.SaveAs(path);
            }
            if (coverLetter != null && coverLetter.ContentLength > 0)
            {
                string[] segments = coverLetter.FileName.Split('.');
                string fileExt = segments[segments.Length - 1];
                var fileName = fileNames[2] + "." + fileExt;
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                coverLetter.SaveAs(path);
            }
            Student model =  studentDAL.GetStudent(username); 
            return View("Index", model);
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
        public ActionResult SearchStudentsByLanguage(string language, string studentClass, string username)
        {
            List<Student> model = studentDAL.GetAllStudentsWithKnowLanguageAndClass(language, studentClass);

            return View("StudentSearchResult", model);
        }

        public ActionResult AddProject(string username)
        {
            Project model = new Project();
            model.StudentUsername = username;
            return View("AddProject", model);
        }

        [HttpPost]
        public ActionResult AddProject(string username, Project newProject)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProject", newProject);
            }
            studentDAL.AddProject(username, newProject);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateStudentContactInfo(string username, string editContactInfo)
        {
            studentDAL.UpdateStudentContactInfo(username, editContactInfo);
            Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult UpdateStudentSummary(string username, string editSummary)
        {
            studentDAL.UpdateStudentSummary(username, editSummary);
             Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult UpdateStudentAcademicDegree(string username, string editAcademicDegree)
        {
            studentDAL.UpdateStudentAcademicDegree(username, editAcademicDegree);
            Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult UpdateStudentPreviousExperience(string username, string editPreviousExperience)
        {
            studentDAL.UpdateStudentPreviousExperience(username, editPreviousExperience);
            Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        public ActionResult AddNewSkill(string username, string addSkill)
        {
            studentDAL.AddStudentSkill(username, addSkill);
            Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        public ActionResult AddNewInterest(string username, string addInterest)
        {
            studentDAL.AddStudentInterest(username, addInterest);
            Student model = studentDAL.GetStudent(username);

            return View("Index", model);
        }

        public ActionResult DeleteStudentSkill(string username, string skill)
        {
            studentDAL.DeleteStudentSkill(username, skill);
            Student model = studentDAL.GetStudent(username);
            return View("Index", model);
        }

        public ActionResult DeleteStudentInterest(string username, string interest)
        {
            studentDAL.DeleteStudentInterest(username, interest);
            Student model = studentDAL.GetStudent(username);

            return View("Index", model);
        }
    }
}