﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class EmployerController : Controller
    {
        // GET: Employer
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult DeleteSkillInterested(string skill)
        {
            return View();
        }

        public ActionResult AddSkillInterested()
        {
            return View();
        }

    }
}