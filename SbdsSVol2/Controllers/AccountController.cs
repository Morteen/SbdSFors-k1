using SbdsSVol2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SbdsSVol2.Controllers
{
    public class AccountController : Controller
    {


        private SbdSContext db = new SbdSContext();
        // GET: Account
        public ActionResult Index()
        {
            List<UserAccount> list = db.UserList.ToList();
            List<Course> courses = db.CoursList.ToList();
            ViewBag.userList = list;
            ViewBag.Courselist = courses;
            ViewBag.UserAtCourse = db.AtCourseList.ToList();


            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount model)
        {

            if (ModelState.IsValid) {
                 
            db.UserList.Add(model);
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = model.Fname + " " + model.Lname + " Du er registrert ved SbdS";

                    }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount model)
        {
           var user= db.UserList.Single(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                Session["UserId"] = user.UserId.ToString();
                Session["UserName"] = user.Fname.ToString();
                return RedirectToAction("LoggedIn");
            }else
            {
                ModelState.AddModelError("", "Passord eller brukernavn er galt");
            }

            return View();
        }



        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                List<Course> liste = db.CoursList.ToList();
                ViewBag.CourseList = liste;
                int tempId = Convert.ToInt32(Session["UserId"]);
                var useratList = db.AtCourseList.Where(u => u.UserId == tempId);
                ViewBag.MineCourseList = useratList.ToList();
                return View();
            }else
            {
                return RedirectToAction("Login");
            }
        }



        public ActionResult AddToCourse(int id)
        {
            if (ModelState.IsValid)
            {


                UserAtCourse at = new UserAtCourse();
                at.CourseId = id;
                at.UserId = Convert.ToInt32(Session["UserId"]);
                db.AtCourseList.Add(at);
                db.SaveChanges();

               
               

            }




            return RedirectToAction("LoggedIn");
        }


        [HttpPost]
        public JsonResult AtCourseDelete(int AtCourseId)
        {

            UserAtCourse at = db.AtCourseList.Find(AtCourseId);
            db.AtCourseList.Remove(at);
            db.SaveChanges();

            //Check to see if Atcourse was actually deleted
            if (db.AtCourseList.Find(AtCourseId) == null)
                return Json(true, JsonRequestBehavior.AllowGet); // yes
            else
                return Json(null, JsonRequestBehavior.AllowGet); // no
        }


    }
}