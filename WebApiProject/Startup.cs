using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiProject.Data;

//to register the dbContext 
using Microsoft.EntityFrameworkCore;
using WebApiProject.Helper_classes;
using WebApiProject.Models;

namespace WebApiProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // Configuration.GetSection("ConnectionStrings"); //this will get whole section from appsettings
            Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container... registers new services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials();
                    });
            });
            // services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("ToDoList")); ;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //adding a single object of cache
            services.AddMemoryCache();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline... adds middleware components
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(MyAllowSpecificOrigins);
           // PersonData.Initialize(app);
            EmployeeData.Initialize(app);
            UserModelData.Initialize(app);
            StudentRegisterationsData.Initialize(app);
            UserData.Initialize(app);
            RegisteredUserData.Initialize(app);
            //MovieData.Initialize(app);
            // PersonData.Initialize(app);
        }
    }
}
