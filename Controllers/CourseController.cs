using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CourseController : Controller
    {
        // Display all courses 
        public ActionResult Index()
        {
            List<Course> courses = new List<Course> {
                 new Course { Title ="ASP.NET MVC", Duration = 20, Price = 2000 },
                 new Course { Title ="Angular", Duration = 10, Price = 1500 },
                 new Course { Title ="Spring", Duration = 20, Price = 3000 }
            };

            return View(courses);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Course course = new Course();
            return View(course);
        }

        [HttpPost]
        public ActionResult Add(Course course)
        {
            return View(course);
        }


    }
}