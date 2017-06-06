using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // Display all courses 
        public ActionResult Index()
        {
            return View(CoursesDatabase.Courses);
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
            // process it 
            CoursesDatabase.Courses.Add(course);
            ViewBag.Message = "Course has been added!";
            return View(course);
        }

        [HttpGet]
        public ActionResult FeeFinder()
        {
            CourseFeeViewModel model = new CourseFeeViewModel();
            model.Timings = "e"; // default is evening 
            return View(model);
        }


        [HttpPost]
        public ActionResult FeeFinder(CourseFeeViewModel model)
        {
            model.CourseFee = model.BaseFee;

            if (model.Timings == "m")
                model.CourseFee = model.CourseFee - model.CourseFee * 10 / 100;

            if (model.OldStudent)
                model.CourseFee = model.CourseFee - model.CourseFee * 10 / 100;

            return View(model);
        }



    }
}