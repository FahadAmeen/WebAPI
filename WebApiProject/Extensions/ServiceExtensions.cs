using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiProject.Models
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("ToDoList"));
        }
    }
}
