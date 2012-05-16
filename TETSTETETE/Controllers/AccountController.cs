using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ELearning.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ELearning.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Det indtastede brugernavn eller den indtastede adgangskode er ikke korrekt.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                MembershipUser user;
                user = Membership.CreateUser(model.UserName, model.Password, null, null, null, true, null, out createStatus);
                

                if (createStatus == MembershipCreateStatus.Success)
                {
                    using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
                    {
                        con.Open();
                        var cmd = new MySqlCommand("INSERT INTO userpoints VALUES (@UserName, @Points)", con);
                        cmd.Parameters.AddWithValue("@UserName", model.UserName);
                        cmd.Parameters.AddWithValue("@Points", 0);
                        cmd.ExecuteNonQuery();
                    }

                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    Roles.AddUserToRole(user.UserName, "Student"); 
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            
            // If we got this far, something failed, redisplay form
            return View(model);
        }

      

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Brugernavnet findes allerede. Indtast venligst et nyt brugernavn.";

                case MembershipCreateStatus.InvalidPassword:
                    return "Den indtastede adgangskode er ikke valid. Indtast venligst en ny adgangskode.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Det indtastede brugernavn er ikke validt. Indtast venligst et nyt brugernavn.";

                case MembershipCreateStatus.ProviderError:
                    return "Der er sket en fejl. Genindtast venligst dine informationer og prøv igen.";

                case MembershipCreateStatus.UserRejected:
                    return "Der er sket en fejl under dannelsen af din bruger. Genindtast venligst dine informationer og prøv igen.";

                default:
                    return "En ukendt fejl er forekommet. Genindtast venligst dine informationer og prøv igen.";
            }
        }
        #endregion
    }
}
