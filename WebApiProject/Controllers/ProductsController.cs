using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        static readonly IProductRepository repository = new ProductRepository();


        [HttpGet("{id}")]

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if(item==null)
            {
                return KeyNotFoundException();
            }
            return item;
        }

        private Product KeyNotFoundException()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        [HttpPost]
        public async Task<Product> PostProductAsync(Product item)
        {
            item = repository.Add(item);
            await repository.SaveChangesAsync();
            return item;
        }

    }
}