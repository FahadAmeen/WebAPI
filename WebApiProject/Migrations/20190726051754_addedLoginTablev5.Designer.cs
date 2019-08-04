﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiProject.Data;

namespace WebApiProject.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190726051754_addedLoginTablev5")]
    partial class addedLoginTablev5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiProject.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Login");

                    b.HasData(
                        new { Id = 1, Email = "fahad@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                        new { Id = 2, Email = "fahd@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                        new { Id = 3, Email = "fahadameen@gmail.com", Password = "eHCl155H53UdHMzLw+nKWA==" },
                        new { Id = 4, Email = "fahadj@gmail.com", Password = "123456" }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Director");

                    b.Property<string>("Genre");

                    b.Property<string>("Poster");

                    b.Property<string>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebApiProject.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasPermission");

                    b.Property<string>("PageURL");

                    b.Property<string>("Pagename");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new { Id = 1, HasPermission = false, PageURL = "http://localhost:4200/home", Pagename = "home" },
                        new { Id = 2, HasPermission = true, PageURL = "http://localhost:4200", Pagename = "movies" },
                        new { Id = 3, HasPermission = false, PageURL = "http://localhost:4200/ranking", Pagename = "ranking" },
                        new { Id = 4, HasPermission = true, PageURL = "http://localhost:4200/movies", Pagename = "movies" }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.RegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email_address");

                    b.Property<string>("FileName");

                    b.Property<string>("Job_type");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone_number");

                    b.HasKey("Id");

                    b.ToTable("RegisteredUsers");
                });

            modelBuilder.Entity("WebApiProject.Models.StudentRegisteration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail");

                    b.Property<string>("Filename");

                    b.Property<string>("Name");

                    b.Property<string>("Program");

                    b.HasKey("Id");

                    b.ToTable("StudentRegisterations");
                });

            modelBuilder.Entity("WebApiProject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Employe_Role");

                    b.Property<string>("File");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApiProject.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice");

                    b.Property<string>("Comments");

                    b.Property<string>("Email");

                    b.Property<string>("FileNames");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserModels");
                });
#pragma warning restore 612, 618
        }
    }
}