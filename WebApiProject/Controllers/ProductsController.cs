//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApiProject.Models;
//using System.Web.Http.Properties;
//using System.Net;
//using System.Net.Http;
//using Microsoft.AspNetCore.Routing;
//using WebApiProject.Models.Interface;
//using OkResult = System.Web.Http.Results.OkResult;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

//namespace WebApiProject.Controllers
//{
//    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ApiController
//    {
//        static readonly IProductRepository Repository=new ProductRepository();

//        [Microsoft.AspNetCore.Mvc.HttpGet]
//        public IEnumerable<Product> GetAllProducts()
//        {
//            return Repository.GetAll();
//        }
        


//        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
//        public Product GetProduct(int id)
//        {
//            Product item = Repository.Get(id);
//            if (item == null)
//            {
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            }
//            return item;
//        }

//        [Microsoft.AspNetCore.Mvc.HttpGet()]
//        [Route("set")]
//        public IEnumerable<Product> GetProductsByCategory(string category)
//        {
//            return Repository.GetAll().Where(
//                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
//        }

//        // POST api/values
//        [Microsoft.AspNetCore.Mvc.HttpPost]
//        public HttpResponseMessage PostProduct(Product item)
//        {
//            item = Repository.Add(item);
//            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

//            string uri = Url.Link("DefaultApi", new { id = item.Id });
//            response.Headers.Location = new Uri(uri);
//            return response;
//        }

        
//        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
//        public bool PutProduct(int id, Product product)
//        {
//            product.Id = id;
//            if (!Repository.Update(product))
//            {
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            }

//            return Repository.Update(product);
//        }

//        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
//        public void DeleteProduct(int id)
//        {
//            Product item = Repository.Get(id);
//            if (item == null)
//            {
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            }

//            Repository.Remove(id);
//        }
//    }

    
//}