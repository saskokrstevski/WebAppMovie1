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
    public class MovieCastsController : Controller
    {
        private MovieDBEntities2 db = new MovieDBEntities2();

        // GET: MovieCasts
        public ActionResult Index()
        {
            var movieCasts = db.MovieCasts.Include(m => m.Movie).Include(m => m.Person).Include(m => m.PersonRole);
            return View(movieCasts.ToList());
        }

        // GET: MovieCasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCast movieCast = db.MovieCasts.Find(id);
            if (movieCast == null)
            {
                return HttpNotFound();
            }
            return View(movieCast);
        }

        // GET: MovieCasts/Create
        public ActionResult Create()
        {
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName");
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonName");
            ViewBag.PersonRoleID = new SelectList(db.PersonRoles, "PersonRoleID", "PersonRole1");
            return View();
        }

        // POST: MovieCasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieCastID,MovieCastName,PersonRoleID,PersonID,MovieID")] MovieCast movieCast)
        {
            if (ModelState.IsValid)
            {
                db.MovieCasts.Add(movieCast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movieCast.MovieID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonName", movieCast.PersonID);
            ViewBag.PersonRoleID = new SelectList(db.PersonRoles, "PersonRoleID", "PersonRole1", movieCast.PersonRoleID);
            return View(movieCast);
        }

        // GET: MovieCasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCast movieCast = db.MovieCasts.Find(id);
            if (movieCast == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movieCast.MovieID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonName", movieCast.PersonID);
            ViewBag.PersonRoleID = new SelectList(db.PersonRoles, "PersonRoleID", "PersonRole1", movieCast.PersonRoleID);
            return View(movieCast);
        }

        // POST: MovieCasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieCastID,MovieCastName,PersonRoleID,PersonID,MovieID")] MovieCast movieCast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieCast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movieCast.MovieID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonName", movieCast.PersonID);
            ViewBag.PersonRoleID = new SelectList(db.PersonRoles, "PersonRoleID", "PersonRole1", movieCast.PersonRoleID);
            return View(movieCast);
        }

        // GET: MovieCasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCast movieCast = db.MovieCasts.Find(id);
            if (movieCast == null)
            {
                return HttpNotFound();
            }
            return View(movieCast);
        }

        // POST: MovieCasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieCast movieCast = db.MovieCasts.Find(id);
            db.MovieCasts.Remove(movieCast);
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
