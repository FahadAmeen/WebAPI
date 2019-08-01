using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.ErrorLog;

namespace WebApiProject.Data
{
    public class LoggingErrorData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.MyLog != null && context.MyLog.Any())
                    return; // DB has already been seeded

                var persons = GetPersons().ToArray();
                if (context.MyLog != null) context.MyLog.AddRange(persons);
                context.SaveChanges();
            }
        }
        public static List<LoggingError> GetPersons()
        {
            List<LoggingError> persons = new List<LoggingError>() {
                new LoggingError { Description = "Not Found 12", Type = " Warn ", Created = "25/07/2019 5:36:56 PM" },
                new LoggingError {Description = "Not Found 200", Type = " Warn ", Created = "25/07/2019 5:37:33 PM" },
                new LoggingError {Description = "System.DivideByZeroExceptionAttemptedtodividebyzerat..", Type = " Error ", Created = "25/07/2019 5:37:36 PM" }
            };
            return persons;
        }
    }
}
