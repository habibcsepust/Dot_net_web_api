using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Dot_net_web_api.Data;
using Dot_net_web_api.Models;

namespace Dot_net_web_api.Controllers
{
    public class TestController : ApiController
    {
        private TestContext db = new TestContext();

        // GET: api/Test
        public IQueryable<Product2> GetProduct2()
        {
            return db.Product2;
        }

        // GET: api/Test/5
        [ResponseType(typeof(Product2))]
        public IHttpActionResult GetProduct2(int id)
        {
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return NotFound();
            }

            return Ok(product2);
        }

        // PUT: api/Test/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct2(int id, Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product2.Id)
            {
                return BadRequest();
            }

            db.Entry(product2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product2Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Test
        [ResponseType(typeof(Product2))]
        public IHttpActionResult PostProduct2(Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product2.Add(product2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product2.Id }, product2);
        }

        // DELETE: api/Test/5
        [ResponseType(typeof(Product2))]
        public IHttpActionResult DeleteProduct2(int id)
        {
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return NotFound();
            }

            db.Product2.Remove(product2);
            db.SaveChanges();

            return Ok(product2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product2Exists(int id)
        {
            return db.Product2.Count(e => e.Id == id) > 0;
        }
    }
}