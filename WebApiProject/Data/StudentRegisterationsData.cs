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
                new StudentRegisteration {Name="userName1",Program="program3",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName2",Program="program14",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName83",Program="program11",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName4",Program="program15",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName15",Program="program111",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName6",Program="program155",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName7",Program="program11",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName18",Program="program16",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName9",Program="program1",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName100",Program="program101",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName11",Program="program10",Detail="detail1",Filename="UserModelFile"},
                new StudentRegisteration {Name="userName120",Program="program81",Detail="detail1",Filename="UserModelFile"},

            };
            return users;
        }
      
    }
}
