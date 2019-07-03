using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class UserModelData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.UserModels != null && context.UserModels.Any())
                    return; // DB has already been seeded

                var users = GetUsers().ToArray();
                if (context.UserModels != null) context.UserModels.AddRange(users);
                context.SaveChanges();
            }
        }
        public static List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>() {
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"},
                new UserModel {Name="userName", Email="userName@gmail.com",Comments="users_comments", Choice="2" ,FileNames="UserModelFile"}

            };
            return users;
        }
    }
}
