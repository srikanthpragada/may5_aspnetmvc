﻿using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            InventoryDataContext ctx = new InventoryDataContext();
            return View(ctx.Categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Category cat = new Category();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Add(Category cat)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            ctx.Categories.InsertOnSubmit(cat);
            ctx.SubmitChanges();

            ViewBag.Message = "Added Category Successfully!";
            return View(cat);
        }

        public ActionResult Delete(String id)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            var cat = (from c in ctx.Categories
                       where c.Code == id
                       select c).SingleOrDefault();

            if ( cat == null)
            {
               TempData["Message"] = "Sorry! Could not delete category with id : " + id;
            }
            ctx.Categories.DeleteOnSubmit(cat);
            ctx.SubmitChanges();

            TempData["Message"] = "Deleted Category Successfully!";
            return RedirectToAction("Index");
        }
    }
}