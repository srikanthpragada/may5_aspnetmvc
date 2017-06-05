using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserName == "admin" && user.Password == "admin")
                   return RedirectToAction("Index");
                else
                {
                    ViewBag.Message = "Invalid Login!";
                }
            }

            return View(user);
        }
    }
}