using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;

namespace ELearning.Controllers
{
    public class StudentAssignmentController : Controller
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();

        //
        // GET: /StudentAssignment/

        public ViewResult Index()
        {
            return View(db.StudentAssignments.ToList());
        }

        public ActionResult SolveAssignment(int userID, int ID, int OptionTaken)
        {
            StudentAssignment studentassignment;
            studentassignment = new StudentAssignment();
            studentassignment.DateTime = DateTime.Now;
            studentassignment.ID = ID;
            studentassignment.userID = userID;
            studentassignment.optionTaken = OptionTaken;
            db.StudentAssignments.Add(studentassignment);
            db.SaveChanges();
            return RedirectToAction("AssignmentSolved", "Assignment");
        }
    }
}
        