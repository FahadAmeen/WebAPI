using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Interfaces
{
    interface ICache
    {
        List<object> GetAll();//get
        object Get(int id);//get
        object Add(object item);//post
        void Remove(int id);//delete
        bool Update(object item);//put

    }
}
