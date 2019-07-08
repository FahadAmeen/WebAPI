using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebApiProject.Models.Interface;

namespace WebApiProject.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.01 });
            Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75 });
        }


        public Product Get(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            item.Id = _nextId++;
            _products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            _products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            { 
                throw new ArgumentNullException(nameof(item));
                return false;
            }

            int index = _products.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }
            _products.RemoveAt(index);
            _products.Add(item);
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        
    }
}
