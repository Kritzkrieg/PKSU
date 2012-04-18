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
    public class AssignmentsController : Controller
    {
        private MySqlConnection db = new MySqlConnection();

        //
        // GET: /Assignments/

        public ViewResult Index()
        {
            return View(db.Assignments.ToList());
        }

        //
        // GET: /Assignments/Details/5

        public ViewResult Details(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            return View(assignment);
        }

        //
        // GET: /Assignments/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Assignments/Create

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
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