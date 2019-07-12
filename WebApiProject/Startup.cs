﻿using System;
using System.Collections.Generic;
using BussinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Data;
//to register the dbContext 

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
           // services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("ToDoList")); ;
            services.AddMvc();

            services.AddTransient<UserModelBL>();
            services.AddTransient<RegisteredUserBL>();
            services.AddTransient<StudentRegisterationBL>();
            services.AddTransient<UserBL>();

            services.AddTransient<Func<string, IUserModelBL>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "UserModel":
                        return serviceProvider.GetService<UserModelBL>();
                    case "RegisteredUser":
                        return serviceProvider.GetService<RegisteredUserBL>();
                    case "StudentRegisteration":
                        return serviceProvider.GetService<StudentRegisterationBL>();
                    case "User":
                        return serviceProvider.GetService<UserBL>();
                    default:
                        throw new KeyNotFoundException(); // or maybe return null, up to you
                }
            });

            services.AddScoped<DbContext, DBContext>();
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
            //PersonData.Initialize(app);
            //EmployeeData.Initialize(app);
            UserModelData.Initialize(app);
            StudentRegisterationsData.Initialize(app);
            UserData.Initialize(app);
            RegisteredUserData.Initialize(app);
            //MovieData.Initialize(app);
           // PersonData.Initialize(app);
        }
    }
}
