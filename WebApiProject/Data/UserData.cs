using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class UserData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Users != null && context.Users.Any())
                    return; // DB has already been seeded

                var users = GetUsers().ToArray();
                if (context.Users != null) context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>() {
                new User {Name="userName1",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName2",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName3",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName4",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName5",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName6",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName7",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName8",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName9",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName10",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName11",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName12",Employe_Role="role",Address="address",File="UserFile"},
                new User {Name="userName13",Employe_Role="role",Address="address",File="UserFile"},


            };
            return users;
        }
    }
}
