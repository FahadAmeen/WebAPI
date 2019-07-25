using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProject.ErrorLog;
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
            base.OnModelCreating(builder);
            builder.Entity<AccessControl>().HasData(
                new AccessControl { Id = 1, Name = "loglevel-list", Url = "http://localhost:4200/logging", Status = "access" },
                new AccessControl { Id = 2, Name = "testpage1", Url = "http://localhost:4200/testpage1", Status = "access" },
                new AccessControl { Id = 3, Name = "testpage2", Url = "http://localhost:4200/testpage2", Status = "denied" }
                 );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<StudentRegisteration> StudentRegisterations { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<ProductRepository> product { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        //public DbSet<Movie> Movies { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public object Mapping { get; internal set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<LoggingError> MyLog { get; set; }
       public DbSet<AccessControl> AccessControl { get; set; }
    }
}
