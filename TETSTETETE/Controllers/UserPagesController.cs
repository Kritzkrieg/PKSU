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
            MembershipUser user = Membership.GetUser(UserName);
            
            StudentAssignmentUser sau;
            sau = new StudentAssignmentUser();
            sau.user = user;

            if (!User.Equals(user)) 
            {
                if (!User.IsInRole("admin"))
                {
                    return RedirectToAction("index", "home");
                }
            }
            return View(sau);
        }

    }
}
