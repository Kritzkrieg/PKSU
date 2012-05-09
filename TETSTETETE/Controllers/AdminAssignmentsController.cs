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
    public class AdminAssignmentsController : Controller
    {
        private AssignmentConnection db = new AssignmentConnection();

        //
        // GET: /Assignments/


        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(db.Assignments.ToList());
            }
            return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
        }

        //
        // GET: /Assignments/Details/5

        public ActionResult Details(int id)
        {
            if (User.IsInRole("admin"))
            {
                Assignment assignment = db.Assignments.Find(id);
                return View(assignment);
            }
            return null;
        }

        //
        // GET: /Assignments/Create

        public ActionResult Create()
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            return View();
        } 

        //
        // POST: /Assignments/Create

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(assignment);
        }
        
        //
        // GET: /Assignments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }
        //
        // POST: /Assignments/Edit/5

        [HttpPost]
        public ActionResult Edit(Assignment assignment)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }



        //
        // GET: /Assignments/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            Assignment assignment = db.Assignments.Find(id);
            return View(assignment);
        }

        //
        // POST: /Assignments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}