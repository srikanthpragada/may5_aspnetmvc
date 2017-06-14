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
        [OutputCache( Duration=60)]
        public ActionResult Index()
        {
            STDbContext ctx = new STDbContext();
            return View(ctx.Courses.ToList());
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
    }
}