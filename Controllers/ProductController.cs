using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string prodname, string minprice)
        {

            HttpContext.Trace.Write("Prodname : " + prodname);
            HttpContext.Trace.Write("Minprice : " + minprice);

            InventoryDataContext ctx = new InventoryDataContext();

            int startPrice = 0;

            if (minprice.Length > 0)
                startPrice = Int32.Parse(minprice);


            var prods = from p in ctx.Products
                        where p.Name.Contains(prodname) &&  p.Price >= startPrice
                        select p;

            
            return PartialView(prods);
        }
    }
}