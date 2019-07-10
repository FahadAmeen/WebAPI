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
using WebApiProject.Models;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Formatting;

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

        // This method gets called by the runtime. Use this method to add services to the container... registers new services
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlSerializerFormatters();


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
            PersonData.Initialize(app);
            EmployeeData.Initialize(app);
            UserModelData.Initialize(app);
            StudentRegisterationsData.Initialize(app);
            UserData.Initialize(app);
            RegisteredUserData.Initialize(app);
        }
        
    }
}
