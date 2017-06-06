using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public String Now()
        {
            return DateTime.Now.ToString();
        }

        public ActionResult Search(String coursename)
        {
            List<Course> courses = new List<Course>();

            foreach(Course c in CoursesDatabase.Courses)
            {
                if (c.Title.Contains(coursename))
                    courses.Add(c);
            }

            return PartialView("Search", courses);
        }


    }
}