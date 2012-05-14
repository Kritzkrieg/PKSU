﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;
using MySql.Web;
using MySql.Data.MySqlClient;
using MySql;

namespace ELearning.Controllers
{

    public class AssignmentController : Controller
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();
        //
        // GET: /Assignment/

        public ActionResult Index()
        {
            GivenAssignment gas = new GivenAssignment();
            gas.gAssignment = Assignment.GetAssignment();
            return View(gas);
        }

        [HttpPost]
        public ActionResult Index(ELearning.Models.GivenAssignment mdl)
        {

            mdl.gAssignment.SolveAssignment();
            return RedirectToAction("Result", "Assignment", mdl);
        }

        public ActionResult Result(ELearning.Models.GivenAssignment mdl)
        {
            return View(mdl);
        }

    }
}
