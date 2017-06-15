using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class STCourseController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            STDbContext ctx = new STDbContext();
            return View(ctx.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            STDbContext ctx = new STDbContext();
            var course = ctx.Courses.Find(id);

            if (course != null)
            {
                ctx.Courses.Remove(course);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View( new DBCourse ());
        }

        [HttpPost]
        public ActionResult Add(DBCourse course)
        {
            try
            {
                STDbContext ctx = new STDbContext();
                ctx.Courses.Add(course);
                ctx.SaveChanges();
                ViewBag.Message = "Course has been added successfully!";
                ModelState.Clear();
                course.Name = "";
                course.Duration = 0;
                course.Fee = 0;
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Sorry! Could not add course! " + ex.Message;
            }

            return View(course);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            STDbContext ctx = new STDbContext();
            var course = ctx.Courses.Find(id);

            if (course != null)
                return View(course);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, DBCourse course)
        {
            try
            {
                STDbContext ctx = new STDbContext();
                var dbCourse = ctx.Courses.Find(id);

                dbCourse.Name = course.Name;
                dbCourse.Duration = course.Duration;
                dbCourse.Fee = course.Fee;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry! Could not update course! Error --> " + ex.Message;
            }

            return View(course);
        }


        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String courseName)
        {
            STDbContext ctx = new STDbContext();

            var courses = from c in ctx.Courses
                              where c.Name.Contains(courseName)
                              select c;

            return PartialView("SearchResults", courses);
        }

    }
}