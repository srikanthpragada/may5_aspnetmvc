using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class CoursesDatabase
    {
        static private List<Course> courses = new List<Course> {
                 new Course { Title ="ASP.NET MVC", Duration = 20, Price = 2000 },
                 new Course { Title ="Angular", Duration = 10, Price = 1500 },
                 new Course { Title ="Spring", Duration = 20, Price = 3000 }
        };

        public static List<Course> Courses
        {
            get
            {
                return courses;
            }
        }

        public static List<SelectListItem> AvailableCourses
        {
            get
            {
                List<SelectListItem> items = new List<SelectListItem>();

                foreach (Course c in CoursesDatabase.Courses)
                    items.Add(new SelectListItem { Text = c.Title, Value = c.Price.ToString() });

                return items;
            }
        }
    }
}