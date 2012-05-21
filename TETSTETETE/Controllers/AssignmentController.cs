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
            //gass.SolveAssignment(User.Identity.Name);
            ViewBag.lolz = mdl.assignmentID;
            return RedirectToAction("Result", "Assignment", gass);
        }

        //Get a specific assignment and the user's choices based on time of completetion
        public ActionResult HistoryResult(int ID, int Opt1, int Opt2, int Opt3)
        {
            GivenAssignment mdl = new GivenAssignment();
            Assignment assignment = Assignment.GetSpecificAssignment(ID);
            mdl.gAssignment = assignment;
            mdl.TheoryAnswer = Opt1;
            mdl.Answer = Opt2;
            mdl.FinalAnswer = Opt3;
                return RedirectToAction("Result", mdl);
        }

        public ActionResult Result(ELearning.Models.GivenAssignment mdl)
        {
            ViewBag.subjects = Assignment.GetSubjects();
            return View(mdl);
        }

    }
}
