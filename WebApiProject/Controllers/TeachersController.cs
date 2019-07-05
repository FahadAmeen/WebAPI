using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        static readonly IRecordRepository repository = new RecordRepository();

        [HttpGet]
        public IEnumerable<Record> GetRecords()
        {
            return repository.GetAll();
        }


        [HttpGet("{id}")]

        public Record GetProduct(int id)
        {
            Record item = repository.Get(id);
            if (item == null)
            {
                return KeyNotFoundException();
            }
            return item;
        }

        private Record KeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task<Record> PostProductAsync(Record item)
        {
            item = repository.Add(item);
            await repository.SaveChangesAsync();
            return item;
        }
        [HttpPut("{id}")]
        public void PutProduct(int id, Record product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            Record item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }

    }

    [Serializable]
    internal class HttpResponseException : Exception
    {
        private object notFound;

        public HttpResponseException()
        {
        }

        public HttpResponseException(object notFound)
        {
            this.notFound = notFound;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}