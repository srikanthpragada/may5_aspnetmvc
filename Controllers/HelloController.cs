using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Wish(String name)
        {
            ViewBag.Message = "Hello, " + name;
            return View();
        }
        public ActionResult  Info()
        {
            Course c = new Course { Title = "Angular", Duration = 10, Price = 2000 };
            return View(c);
        }
    }
}