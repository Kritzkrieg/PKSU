using System;
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
            ModelState.Clear();
            GivenAssignment gas = new GivenAssignment();
            gas.gAssignment = Assignment.GetAssignment(User.Identity.Name);
            
            return View(gas);
        }

        [HttpPost]
        public ActionResult Index(ELearning.Models.GivenAssignment mdl)
        {
            GivenAssignment gass = mdl;
            Assignment ass = Assignment.GetSpecificAssignment(mdl.assignmentID);
            gass.gAssignment = ass;
            gass.SolveAssignment(User.Identity.Name);

            return RedirectToAction("Result", "Assignment", gass);
        }

        //Get a specific assignment and the user's choices based on time of completetion
        public ActionResult HistoryResult(int ID, int Opt1, int Opt2, int Opt3)
        {
            GivenAssignment mdl = new GivenAssignment();
            mdl.TheoryAnswer = Opt1;
            mdl.Answer = Opt2;
            mdl.FinalAnswer = Opt3;
            return RedirectToAction("Result", mdl);
        }

        public ActionResult Result(ELearning.Models.GivenAssignment mdl)
        {
            
            //Get assignment
            Assignment assignment = Assignment.GetSpecificAssignment(mdl.assignmentID);
            mdl.gAssignment = new Assignment();
            mdl.gAssignment = assignment;
            //Check which parts of Result page to hide

            ViewBag.ShowTheory = 1; ViewBag.ShowMiddle = 1; ViewBag.ShowFinal = 1;
            if (mdl.gAssignment.TruetOption.Equals(5)) { ViewBag.ShowTheory = 0; }
            if (mdl.gAssignment.TrueOption.Equals(5)) { ViewBag.ShowMiddle = 0; }
            if (mdl.gAssignment.TruefOption.Equals(5)) { ViewBag.ShowFinal = 0; }
            return View(mdl);
        }

    }
}
