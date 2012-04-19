using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELearning.Models;

namespace ELearning.Controllers
{
    public class UserListController : Controller
    {
        //
        // GET: /UserList/

        private MySqlConnection db = new MySqlConnection();
        
        
        public ActionResult Index()
        {
            var users = Membership.GetAllUsers();
            return View(users);
        }

        public ActionResult UserProfile(string UserName = "0")
        {
            MembershipUser user = Membership.GetUser(UserName);
            return View(user);
        }

    }
}
