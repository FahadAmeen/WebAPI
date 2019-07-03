using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class EmployeeData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Employees != null && context.Employees.Any())
                    return; // DB has already been seeded

                var employees = GetEmployees().ToArray();
                if (context.Employees != null) context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }
        public static List<Employee> GetEmployees()
        {
            List<Employee> persons = new List<Employee>() {
                new Employee {Designation="d1",Salary=25000},
                new Employee {Designation="d2",Salary=30000},
                new Employee {Designation="d3",Salary=20005},
                new Employee {Designation="d4",Salary=10025},
                new Employee {Designation="d1",Salary=25000},
                new Employee {Designation="d2",Salary=30000},
                new Employee {Designation="d3",Salary=20005},
                new Employee {Designation="d4",Salary=10025},
                new Employee {Designation="d1",Salary=25000},
                new Employee {Designation="d2",Salary=30000},
                new Employee {Designation="d3",Salary=20005},
                new Employee {Designation="d4",Salary=10025},
                new Employee {Designation="d1",Salary=25000},
                new Employee {Designation="d2",Salary=30000},
                new Employee {Designation="d3",Salary=20005},
                new Employee {Designation="d4",Salary=10025}
            };
            return persons;
        }
    }
}
