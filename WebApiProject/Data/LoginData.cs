using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class LoginData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Login != null && context.Login.Any())
                    return; // DB has already been seeded

                var users = GetUsers().ToArray();
                if (context.Login != null) context.Login.AddRange(users);
                context.SaveChanges();
            }
        }
        public static List<Login> GetUsers()
        {
            List<Login> users = new List<Login>() {
                new Login { Id = 1, Email = "fahad@gmail.com", Password = "123456"},
                new Login { Id = 1, Email = "fahd@gmail.com", Password = "123456" },
                new Login { Id = 1, Email = "fahadameen@gmail.com", Password = "123456" }

            };
            return users;
        }
    }
}
