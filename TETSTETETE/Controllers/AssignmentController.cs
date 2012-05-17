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
            
            Assignment ass = Assignment.GetSpecificAssignment(mdl.assignmentID);
            mdl.gAssignment = ass;
            mdl.SolveAssignment(User.Identity.Name);
            return RedirectToAction("Result", "Assignment", mdl);
        }

        //Get a specific assignment and the user's choices based on time of completetion
        public ActionResult HistoryResult(Assignment assignment, string username, string datetime)
        {
            GivenAssignment mdl = new GivenAssignment();
            mdl.gAssignment = assignment;
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT OptionTaken1, OptionTaken2, OptionTaken3 FROM studentassignment WHERE UserName = @UserName AND ID = @ID AND DateTime = @DateTime", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@ID", assignment.ID);
                cmd.Parameters.AddWithValue("@DateTime", datetime);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    mdl.TheoryAnswer = r.GetInt32(0);
                    mdl.Answer = r.GetInt32(1);
                    mdl.FinalAnswer = r.GetInt32(2);
                    
                }
            }
                return RedirectToAction("Result", mdl);
        }

        public ActionResult Result(ELearning.Models.GivenAssignment mdl)
        {
            ViewBag.subjects = Assignment.GetSubjects();
            return View(mdl);
        }

    }
}
