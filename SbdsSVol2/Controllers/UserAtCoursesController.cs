using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SbdsSVol2.Models;

namespace SbdsSVol2.Controllers
{
    public class UserAtCoursesController : Controller
    {
        private SbdSContext db = new SbdSContext();

        // GET: UserAtCourses
        public ActionResult Index()
        {
            var atCourseList = db.AtCourseList.Include(u => u.Course).Include(u => u.UserAccount);
            return View(atCourseList.ToList());
        }

        // GET: UserAtCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAtCourse userAtCourse = db.AtCourseList.Find(id);
            if (userAtCourse == null)
            {
                return HttpNotFound();
            }
            return View(userAtCourse);
        }

        // GET: UserAtCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.CoursList, "CourseId", "Name");
            ViewBag.UserId = new SelectList(db.UserList, "UserId", "Fname");
            return View();
        }

        // POST: UserAtCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtCourseId,UserId,CourseId")] UserAtCourse userAtCourse)
        {
            if (ModelState.IsValid)
            {
                db.AtCourseList.Add(userAtCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.CoursList, "CourseId", "Name", userAtCourse.CourseId);
            ViewBag.UserId = new SelectList(db.UserList, "UserId", "Fname", userAtCourse.UserId);
            return View(userAtCourse);
        }

        // GET: UserAtCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAtCourse userAtCourse = db.AtCourseList.Find(id);
            if (userAtCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CoursList, "CourseId", "Name", userAtCourse.CourseId);
            ViewBag.UserId = new SelectList(db.UserList, "UserId", "Fname", userAtCourse.UserId);
            return View(userAtCourse);
        }

        // POST: UserAtCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtCourseId,UserId,CourseId")] UserAtCourse userAtCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAtCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CoursList, "CourseId", "Name", userAtCourse.CourseId);
            ViewBag.UserId = new SelectList(db.UserList, "UserId", "Fname", userAtCourse.UserId);
            return View(userAtCourse);
        }

        // GET: UserAtCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAtCourse userAtCourse = db.AtCourseList.Find(id);
            if (userAtCourse == null)
            {
                return HttpNotFound();
            }
            return View(userAtCourse);
        }

        // POST: UserAtCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAtCourse userAtCourse = db.AtCourseList.Find(id);
            db.AtCourseList.Remove(userAtCourse);
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
