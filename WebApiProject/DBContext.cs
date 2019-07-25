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

            builder.Entity<ToDoItem>().HasData(
                new ToDoItem("remove bugs", true, "removing ", "high")
                {
                    Id = 1

                }, new ToDoItem("work on table ", true, "removing ", "high")
                {
                    Id = 2
                }, new ToDoItem("estimate time", false, "removing ", "high")
                {
                    Id = 3
                }, new ToDoItem("blah blah", true, "removing ", "major")
                {
                    Id = 4
                }, new ToDoItem("yes no", true, "removing ", "high")
                {
                    Id = 5
                }, new ToDoItem("update web apo", false, "removing ", "medium")
                {
                    Id = 6
                }, new ToDoItem("this is working", false, "removing ", "medium")
                {
                    Id = 7
                }, new ToDoItem("ahan", true, "removing ", "low")
                {
                    Id = 8
                });

            builder.Entity<Permission>().HasData(
                new Permission("/home", true)
                {
                    Name = "Welcome Page",
                    Id=1

                }, new Permission("/login", true)
                {
                    Name = "Login Page",
                    Id = 2
                }, new Permission("/todoitems", false)
                {
                    Name = "Todo Page",
                    Id = 3
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
        public DbSet<Permission> Permission { get; set; }

    }
}
