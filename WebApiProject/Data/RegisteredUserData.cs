using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class RegisteredUserData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.RegisteredUsers != null && context.RegisteredUsers.Any())
                    return; // DB has already been seeded

                var persons = GetPersons().ToArray();
                if (context.RegisteredUsers != null) context.RegisteredUsers.AddRange(persons);
                context.SaveChanges();
            }
        }
        public static List<RegisteredUser> GetPersons()
        {
            List<RegisteredUser> persons = new List<RegisteredUser>() {
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},
                new RegisteredUser {Name="userName", Email_address="userName@gmail.com",Phone_number="+923367455435", Job_type="type1" ,Password="password",FileName="filename"},

            };
            return persons;
        }
    }
}
