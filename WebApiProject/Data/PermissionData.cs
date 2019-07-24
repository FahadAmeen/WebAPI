using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class PermissionData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Permission != null && context.Permission.Any())
                    return; // DB has already been seeded

                var permissionList = GetPermissionList().ToArray();
                if (context.Permission != null) context.Permission.AddRange(permissionList);
                context.SaveChanges();
            }
        }
        public static List<Permission> GetPermissionList()
        {
            List<Permission> permissionList = new List<Permission>() {
                new Permission {Pagename = "home", PageURL = "http://localhost:4200/home",HasPermission = false},
                new Permission {Pagename = "movies", PageURL = "http://localhost:4200",HasPermission = true},
                new Permission {Pagename = "ranking", PageURL = "http://localhost:4200/ranking",HasPermission = false},
            };
            return permissionList;
        }
    }
}
