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
        [HttpPost]
        public ActionResult Index(ELearning.Models.Assignment mdl)
        {

            mdl.SolveAssignment();
            return RedirectToAction("Result", "Assignment", mdl);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Result(ELearning.Models.Assignment mdl)
        {
            return View(mdl);
        }

    }
}
