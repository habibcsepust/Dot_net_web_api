using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dot_net_web_api.Models;

namespace Dot_net_web_api.Controllers
{
    public class Product2Controller : ApiController
    {

        //static List<string> products = new List<string>() {
        //    "Laptop","Phone","PC"
        //};

        //[HttpGet]
        //public List<string> GetAll() {
        //    return products;
        //}

        //[HttpGet]
        //public string GetById(int id) {
        //    return products[id];
        //}

        //[HttpGet]
        //public List<string> Save(string productNsme) {
        //    products.Add(productNsme);
        //    return products;
        //}

        //[HttpGet]
        //public List<string> Update(int id,string productNsme)
        //{
        //    products[id] = productNsme;
        //    return products;
        //}

        //[HttpGet]
        //public List<string> Delete(int id)
        //{
        //    products.RemoveAt(id);
        //    return products;
        //}


       

        ApplicationDbContext _db = new ApplicationDbContext();


        /// <summary>
        /// Saved Product into database
        /// </summary>
        /// 

        //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpPost]
        public IHttpActionResult Add([FromBody]Product2 product2) {
            _db.product2s.Add(product2);
            int rowCount =_db.SaveChanges();
            if (rowCount > 0) {
                return Ok("Successfully Added..");
            }
            return BadRequest("Bad request..");
        }


        /// <summary>
        /// Get product get by an ID
        /// </summary>
        [HttpGet]
        public IHttpActionResult GetById(int id) {
            Product2 product2 = _db.product2s.FirstOrDefault(c=>c.Id==id);
            if (product2 == null) {
                return NotFound();
            }
            return Ok(product2);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        [HttpPut]
        public IHttpActionResult Update([FromBody]Product2 product2) {
            if (product2.Id == 0) {
                return NotFound();
            }

            _db.Entry(product2).State = System.Data.Entity.EntityState.Modified;
            int rowCount = _db.SaveChanges();
            if (rowCount > 0) {
                return Ok(product2);
            }
            return BadRequest("Modified Failed");
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            Product2 product2 = _db.product2s.FirstOrDefault(c => c.Id == id);
            if (product2 == null) {
                return NotFound();
            }
            _db.product2s.Remove(product2);
            int rowCount = _db.SaveChanges();
            if (rowCount > 0) {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Failed to delete");

        }
    }
}
