using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dot_net_web_api.Controllers
{
    public class Product2Controller : ApiController
    {

        static List<string> products = new List<string>() {
            "Laptop","Phone","PC"
        };

        [HttpGet]
        public List<string> GetAll() {
            return products;
        }

        [HttpGet]
        public string GetById(int id) {
            return products[id];
        }

        [HttpGet]
        public List<string> Save(string productNsme) {
            products.Add(productNsme);
            return products;
        }

        [HttpGet]
        public List<string> Update(int id,string productNsme)
        {
            products[id] = productNsme;
            return products;
        }

        [HttpGet]
        public List<string> Delete(int id)
        {
            products.RemoveAt(id);
            return products;
        }
    }
}
