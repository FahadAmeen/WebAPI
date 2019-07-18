using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Helper_classes;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //EF Seed object creation
            
            base.OnModelCreating(builder);

            builder.Entity<Login>().HasData(
                new Login("sahar", "12345678")
                {
                    UserId = 1 

                }, new Login("saba tahir", "hello s")
                {
                    UserId = 2
                }, new Login("Alina Ali", "alina ali")
                {
                    UserId = 3
                });
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<StudentRegisteration> StudentRegisterations { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<ProductRepository> product { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public object Mapping { get; internal set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Login> Login { get; set; }

    }
}
