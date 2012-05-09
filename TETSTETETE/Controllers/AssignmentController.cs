﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;

namespace ELearning.Controllers
{

    public class AssignmentController : Controller
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();
        //
        // GET: /Assignment/
        [HttpPost]
        public ActionResult Index(ELearning.Models.StaticAssignment mdl)
        {
            return RedirectToAction("Result", "Assignment", mdl);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(ELearning.Models.StaticAssignment mdl)
        {
            mdl.SolveAssignment();
            return View(mdl);
        }

    }
}
