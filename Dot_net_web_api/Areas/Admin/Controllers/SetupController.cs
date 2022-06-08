using Dot_net_web_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dot_net_web_api.Areas.Admin.Controllers
{
    public class SetupController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: Admin/Setup
        public async Task<ActionResult> GetProduct()
        {
            List<Product2> product2s = new List<Product2>();
            var baseUri = "https://localhost:44325/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Product2/GetAll");

                if (res.IsSuccessStatusCode) {
                    var productList = res.Content.ReadAsStringAsync().Result;
                    product2s = JsonConvert.DeserializeObject<List<Product2>>(productList);
                }
            }
            return View(product2s);
        }

        public ActionResult SaveProduct() {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> SaveProduct(Product2 product2)
        {
            var baseUri = "https://localhost:44325/";

            string msg = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PostAsJsonAsync<Product2>("api/Product2/Add", product2);

                if (res.IsSuccessStatusCode)
                {
                    msg = "Product saved successfully.";
                }
                else 
                {
                    msg = "Save failed.";
                }
                ViewBag.message = msg;
            }
            return View();
        }


        public async Task<ActionResult> Edit(int id)
        {

            if (id < 0 && id == 0) {
                return RedirectToAction("Index");
            }
            Product2 product2 = new Product2();
            var baseUri = "https://localhost:44325/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Product2/GetById?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var product = res.Content.ReadAsStringAsync().Result;
                    product2 = JsonConvert.DeserializeObject<Product2>(product);
                }
            }
            return View(product2);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product2 product2)
        {
            Product2 product = new Product2();
            var baseUri = "https://localhost:44325/";

            string msg = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PostAsJsonAsync<Product2>("api/Product2/Add", product2);

                if (res.IsSuccessStatusCode)
                {
                    msg = "Product Updated successfully.";
                }
                else
                {
                    msg = "Update failed.";
                }
                ViewBag.message = msg;
            }
            return View(product);
        }

    }
}