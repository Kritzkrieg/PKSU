using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELearning.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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


            //Get most active day
            ViewBag.MActive = "0000000000";
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT DateTime, count(*) as occurrences, ID, OptionTaken1, OptionTaken2, OptionTaken3, Solved1, Solved2, Solved3 FROM studentassignment WHERE UserName= ? GROUP BY DateTime ORDER BY occurrences desc, DateTime LIMIT 1", con);
                cmd.Parameters.AddWithValue("?", UserName);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        ViewBag.MActive = r.GetString(0);
                    }
                }
            }
            
            return View(sau);
        }

    }
}
