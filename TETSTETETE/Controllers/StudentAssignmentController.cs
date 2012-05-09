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

        
    }
}
        