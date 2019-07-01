using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;
using System.Web.Http.Properties;
using System.Net;
using System.Net.Http;

namespace WebApiProject.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository=new ProductRepository();

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        [System.Web.Http.HttpGet]
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        //// POST api/values
        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //public Product PostProduct(Product item)
        //{
        //    item = repository.Add(item);
        //    return item;
        //}

        // POST api/values
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [System.Web.Http.HttpPut]
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }

    
}