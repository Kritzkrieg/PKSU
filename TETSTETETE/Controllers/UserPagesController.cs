using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELearning.Models;
using System.Data.SqlClient;

namespace ELearning.Controllers
{
    public class UserPagesController : Controller
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();
        //
        // GET: /UserPages/

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult UserProfile(string UserName = "0")
        {
            StudentAssignmentUser sau = new StudentAssignmentUser();
            var StudentsAssignments = StudentAssignment.GetStudentsAssignments(UserName);
            MembershipUser user = Membership.GetUser(UserName);
            sau.studentassignment = StudentsAssignments;
            sau.user = user;

            if (!User.IsInRole("admin") && !User.IsInRole("student"))
            {
                return RedirectToAction("Index", "Home");
            }

            if (!User.Identity.Name.Equals(UserName)) 
            {
                if (!User.IsInRole("admin"))
                {
                    return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
                }
            }

            return View(sau);
        }

    }
}
