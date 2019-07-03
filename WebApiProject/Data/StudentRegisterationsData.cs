using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class StudentRegisterationsData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.StudentRegisterations != null && context.StudentRegisterations.Any())
                    return; // DB has already been seeded

                var studentRegisterations = GetUsers().ToArray();
                if (context.StudentRegisterations != null) context.StudentRegisterations.AddRange(studentRegisterations);
                context.SaveChanges();
            }
        }
        public static List<StudentRegisteration> GetUsers()
        {
            List<StudentRegisteration> users = new List<StudentRegisteration>() {
                new StudentRegisteration {Name="userName1",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName2",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName3",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName4",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName5",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName6",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName7",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName8",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName9",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName10",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName11",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName12",Program="program1",Detail="detail1",Filename="UserModelFile"},

            };
            return users;
        }
    }
}
