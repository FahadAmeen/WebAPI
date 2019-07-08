using System.Collections.Generic;

namespace WebApiProject.Models.Interface
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();//get
        Product Get(int id);//get
        Product Add(Product item);//post
        void Remove(int id);//delete
        bool Update(Product item);//put

    }
}
