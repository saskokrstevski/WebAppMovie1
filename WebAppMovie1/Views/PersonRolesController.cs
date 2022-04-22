using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMovie1.Models;

namespace WebAppMovie1.Views
{
    public class PersonRolesController : Controller
    {
        private MovieDBEntities2 db = new MovieDBEntities2();

        // GET: PersonRoles
        public ActionResult Index()
        {
            return View(db.PersonRoles.ToList());
        }

        // GET: PersonRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonRole personRole = db.PersonRoles.Find(id);
            if (personRole == null)
            {
                return HttpNotFound();
            }
            return View(personRole);
        }

        // GET: PersonRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonRoleID,PersonRole1")] PersonRole personRole)
        {
            if (ModelState.IsValid)
            {
                db.PersonRoles.Add(personRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personRole);
        }

        // GET: PersonRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonRole personRole = db.PersonRoles.Find(id);
            if (personRole == null)
            {
                return HttpNotFound();
            }
            return View(personRole);
        }

        // POST: PersonRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonRoleID,PersonRole1")] PersonRole personRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personRole);
        }

        // GET: PersonRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonRole personRole = db.PersonRoles.Find(id);
            if (personRole == null)
            {
                return HttpNotFound();
            }
            return View(personRole);
        }

        // POST: PersonRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonRole personRole = db.PersonRoles.Find(id);
            db.PersonRoles.Remove(personRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
