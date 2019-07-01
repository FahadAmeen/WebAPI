﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PersonContext>();
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
                new Person {Name="person1"},
                new Person {Name="person2"},
                new Person {Name="person3"},
                new Person {Name="person4"}
            };
            return persons;
        }

    }
}
