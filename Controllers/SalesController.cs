using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class SalesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Sale> Get()
        {
           //  Thread.Sleep(5000);
            InventoryDataContext ctx = new InventoryDataContext();
            return ctx.Sales; 
        }

        // GET api/<controller>/5
        public Sale Get(int id)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            var sale = (from s in ctx.Sales
                        where s.Invno == id
                        select s).SingleOrDefault();
            if (sale != null)
                return sale;
            else
            {
                HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(msg);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            var sale = (from s in ctx.Sales
                        where s.Invno == id
                        select s).SingleOrDefault();
            
            if (sale == null)
            {
                HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(msg);
            }

            try
            {
                ctx.Sales.DeleteOnSubmit(sale);
                ctx.SubmitChanges();
            }
            catch(Exception ex)
            {
                HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new HttpResponseException(msg);
            }
        }
    }
}