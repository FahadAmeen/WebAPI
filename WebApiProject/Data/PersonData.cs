using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class PersonData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Persons != null && context.Persons.Any())
                    return; // DB has already been seeded

                var persons = GetPersons().ToArray();
                if (context.Persons != null) context.Persons.AddRange(persons);
                context.SaveChanges();
            }
        }
        public static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>() {
                new Person {Name="p1",Age=25,Gender="Male"},
                new Person {Name="p2",Age=25,Gender="Male"},
                new Person {Name="p3",Age=25,Gender="Male"},
                new Person {Name="p4",Age=25,Gender="Female"},
                new Person {Name="p5",Age=25,Gender="Male"},
                new Person {Name="p2",Age=25,Gender="Male"},
                new Person {Name="p3",Age=25,Gender="Male"},
                new Person {Name="p4",Age=25,Gender="Male"}
            };
            return persons;
        }

    }
}
