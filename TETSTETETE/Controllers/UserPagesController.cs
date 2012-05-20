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

        public ActionResult HistoryResult(int ID, int Opt1, int Opt2, int Opt3)
        {
            return RedirectToAction("HistoryResult", "Assignment", new { ID = ID, Opt1 = Opt1, Opt2 = Opt2, Opt3 = Opt3 });
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
            ViewBag.MActive = "           ";
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT SUBSTRING(DateTime, 1, 10) as 'DateTime', count(*) as occurrences, ID, OptionTaken1, OptionTaken2, OptionTaken3, Solved1, Solved2, Solved3 FROM studentassignment WHERE UserName= ? GROUP BY DateTime ORDER BY occurrences desc, DateTime LIMIT 1", con);
                cmd.Parameters.AddWithValue("?", UserName);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        ViewBag.MActive = r.GetString(0);
                    }
                }
            }
            
            //Get top 10
            string[] tTen = new string[20];
            ViewBag.TopTen = tTen;
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT `UserName`, `Points` FROM userpoints GROUP BY 1 ORDER BY 2 DESC LIMIT 0,10", con);
                using (var r = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (r.Read())
                    {
                        ViewBag.TopTen[i] = r.GetString(0);
                        ViewBag.TopTen[i+1] = r.GetString(1);
                        i = i + 2;
                    }
                }
            }

            return View(sau);
        }

    }
}
