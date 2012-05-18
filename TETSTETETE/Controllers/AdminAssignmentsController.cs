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

        //
        // GET: /Assignments/


        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                var allAssignments = Assignment.GetAllAssignments();
                return View(allAssignments);
            }
            return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
        }

        //
        // GET: /Assignments/Details/5

        public ActionResult Details(int id)
        {
            if (User.IsInRole("admin"))
            {
                Assignment assignment = Assignment.GetSpecificAssignment(id);
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
            ViewBag.subjects = Assignment.GetSubjects();
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
                Assignment.AddAssignment(assignment);
                return RedirectToAction("Index");  
            }
            ViewBag.subjects = Assignment.GetSubjects();
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
            Assignment assignment = Assignment.GetSpecificAssignment(id);
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
                Assignment.EditAssignment(assignment);
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
            Assignment assignment = Assignment.GetSpecificAssignment(id);
            return View(assignment);
        }

        //
        // POST: /Assignments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment.DeleteAssignment(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Assignments/CreateSubject

        [HttpPost]
        public ActionResult CreateSubject()
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("UserProfile", "UserPages", new { UserName = User.Identity.Name });
            }
            return View();
        }
    }
}