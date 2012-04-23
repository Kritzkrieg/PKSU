using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELearning.Models;

namespace ELearning.Controllers
{
    public class UserPagesController : Controller
    {
        //
        // GET: /UserPages/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile(string UserName = "0")
        {
            MembershipUser user = Membership.GetUser(UserName);
            return View(user);
        }

    }
}
