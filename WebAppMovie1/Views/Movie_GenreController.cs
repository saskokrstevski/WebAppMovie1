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
    public class Movie_GenreController : Controller
    {
        private MovieDBEntities2 db = new MovieDBEntities2();

        // GET: Movie_Genre
        public ActionResult Index()
        {
            var movie_Genre = db.Movie_Genre.Include(m => m.Genre).Include(m => m.Movie);
            return View(movie_Genre.ToList());
        }

        // GET: Movie_Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Genre movie_Genre = db.Movie_Genre.Find(id);
            if (movie_Genre == null)
            {
                return HttpNotFound();
            }
            return View(movie_Genre);
        }

        // GET: Movie_Genre/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Genre1");
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName");
            return View();
        }

        // POST: Movie_Genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie_GenreID,GenreID,MovieID")] Movie_Genre movie_Genre)
        {
            if (ModelState.IsValid)
            {
                db.Movie_Genre.Add(movie_Genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Genre1", movie_Genre.GenreID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Genre.MovieID);
            return View(movie_Genre);
        }

        // GET: Movie_Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Genre movie_Genre = db.Movie_Genre.Find(id);
            if (movie_Genre == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Genre1", movie_Genre.GenreID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Genre.MovieID);
            return View(movie_Genre);
        }

        // POST: Movie_Genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie_GenreID,GenreID,MovieID")] Movie_Genre movie_Genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie_Genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Genre1", movie_Genre.GenreID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Genre.MovieID);
            return View(movie_Genre);
        }

        // GET: Movie_Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Genre movie_Genre = db.Movie_Genre.Find(id);
            if (movie_Genre == null)
            {
                return HttpNotFound();
            }
            return View(movie_Genre);
        }

        // POST: Movie_Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie_Genre movie_Genre = db.Movie_Genre.Find(id);
            db.Movie_Genre.Remove(movie_Genre);
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
