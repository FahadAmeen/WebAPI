using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

            builder.Entity<Permission>().HasData(
                new Permission {Id = 1,Pagename = "home", PageURL = "http://localhost:4200/home",HasPermission = false}, 
                new Permission { Id = 2, Pagename = "movies", PageURL = "http://localhost:4200",HasPermission = true},
                new Permission { Id = 3, Pagename = "ranking", PageURL = "http://localhost:4200/ranking",HasPermission = false},
                new Permission { Id = 4, Pagename = "movies", PageURL = "http://localhost:4200/movies", HasPermission = true }
            );
            builder.Entity<Login>().HasData(
                new Login { Id = 1, Email = "fahad@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                new Login { Id = 2, Email = "fahd@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                new Login { Id = 3, Email = "fahadameen@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                new Login { Id = 4, Email = "fahadj@gmail.com", Password = "123456" }


            );

        }
        
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<StudentRegisteration> StudentRegisterations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Permission> Permission { get; set; }

        public DbSet<Login> Login { get; set; }


    }
}
