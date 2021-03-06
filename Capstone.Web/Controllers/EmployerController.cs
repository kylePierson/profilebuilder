﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Data.Models;
using Capstone.Data.DataAccess;

namespace Capstone.Web.Controllers
{
    public class EmployerController : Controller
    {
        IEmployerDAL employerDAL;
        IStudentDAL studentDAL;

        public EmployerController(IEmployerDAL employerDal, IStudentDAL studentDAL)
        {    
            this.employerDAL = employerDal;
            this.studentDAL = studentDAL;
        }
        // GET: Employer
        public ActionResult Index(string username)
        {
            

            Employer model = employerDAL.GetEmployer(username);

            return View("Index",model);
        }

        public ActionResult DeleteSkillInterested(string skill, string username)
        {
           
            employerDAL.DeleteInterest(skill, username);
            Employer model = employerDAL.GetEmployer(username);
            return View("Index", model);
        }

        public bool AddSkillInterested(string interest, string username)
        {
            
            employerDAL.AddInterest(username, interest);
            Employer model = employerDAL.GetEmployer(username);

            return true;
        }

        public ActionResult ViewStudent(string username)
        {
            Student model = studentDAL.GetStudent(username);

            return View("ViewStudent", model);
        }
    }
}