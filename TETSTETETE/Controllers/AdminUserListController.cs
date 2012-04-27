using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELearning.Models;

namespace ELearning.Controllers
{
    public class AdminUserListController : Controller
    {
        //
        // GET: /UserList/

        private AssignmentConnection db = new AssignmentConnection();
        
        
        public ActionResult Index()
        {
            var users = Membership.GetAllUsers();
            return View(users);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword(string UserName)
        {
            ViewBag.UserName = UserName;
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                string OldPassword;
                string NewPassword;
                bool changePasswordSucceeded;
                try
                {
                    // Get user
                    MembershipUser currentUser = Membership.GetUser(model.UserName);

                    // Get old password
                    OldPassword = currentUser.GetPassword();

                    // Get new password
                    NewPassword = model.NewPassword;
                    changePasswordSucceeded = currentUser.ChangePassword(OldPassword, NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "OldPass:" + Membership.GetUser(model.UserName).GetPassword() + "NewPass:" + model.NewPassword + "User:" + model.UserName);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult UserProfile(string UserName = "0")
        {
            return RedirectToAction("UserProfile", "UserPages", new { UserName = UserName });
        }

    }
}
