﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiProject.Data;

namespace WebApiProject.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation");

                    b.Property<int>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApiProject.Models.Login", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Password");

                    b.Property<string>("UserEmail");

                    b.HasKey("UserId");

                    b.ToTable("Login");

                    b.HasData(
                        new { UserId = 1, Password = new byte[] { 66, 145, 205, 222, 149, 121, 112, 56, 178, 91, 82, 92, 149, 28, 154, 233 }, UserEmail = "sej@ciklum.com" },
                        new { UserId = 2, Password = new byte[] { 15, 154, 179, 67, 101, 118, 152, 215, 18, 220, 20, 210, 161, 5, 150, 209 }, UserEmail = "saba_tahir@yahoo.com" },
                        new { UserId = 3, Password = new byte[] { 222, 181, 24, 67, 220, 146, 43, 164, 232, 212, 154, 113, 246, 185, 241, 13 }, UserEmail = "AlinaAli@rocketmail.com" }
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

                    b.Property<string>("Name");

                    b.Property<string>("PageUrl");

                    b.Property<bool>("isAccessible");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new { Id = 1, Name = "Welcome Page", PageUrl = "/home", isAccessible = true },
                        new { Id = 2, Name = "Login Page", PageUrl = "/login", isAccessible = true },
                        new { Id = 3, Name = "Todo Page", PageUrl = "/todoitems", isAccessible = false }
                    );
                });

            modelBuilder.Entity("WebApiProject.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WebApiProject.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Records");
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

            modelBuilder.Entity("WebApiProject.Models.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("File");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Priority");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new { Id = 1, Description = "removing ", IsComplete = true, Priority = "high", Title = "remove bugs" },
                        new { Id = 2, Description = "removing ", IsComplete = true, Priority = "high", Title = "work on table " },
                        new { Id = 3, Description = "removing ", IsComplete = false, Priority = "high", Title = "estimate time" },
                        new { Id = 4, Description = "removing ", IsComplete = true, Priority = "major", Title = "blah blah" },
                        new { Id = 5, Description = "removing ", IsComplete = true, Priority = "high", Title = "yes no" },
                        new { Id = 6, Description = "removing ", IsComplete = false, Priority = "medium", Title = "update web apo" },
                        new { Id = 7, Description = "removing ", IsComplete = false, Priority = "medium", Title = "this is working" },
                        new { Id = 8, Description = "removing ", IsComplete = true, Priority = "low", Title = "ahan" },
                        new { Id = 9, Description = "removing ", IsComplete = true, Priority = "high", Title = "remove bugs" },
                        new { Id = 10, Description = "removing ", IsComplete = true, Priority = "high", Title = "work on table " },
                        new { Id = 13, Description = "removing ", IsComplete = false, Priority = "high", Title = "estimate time" },
                        new { Id = 14, Description = "removing ", IsComplete = true, Priority = "major", Title = "blah blah" },
                        new { Id = 15, Description = "removing ", IsComplete = true, Priority = "high", Title = "yes no" },
                        new { Id = 16, Description = "removing ", IsComplete = false, Priority = "medium", Title = "update web apo" },
                        new { Id = 17, Description = "removing ", IsComplete = false, Priority = "medium", Title = "this is working" },
                        new { Id = 18, Description = "removing ", IsComplete = true, Priority = "low", Title = "ahan" },
                        new { Id = 11, Description = "removing ", IsComplete = true, Priority = "high", Title = "remove bugs" },
                        new { Id = 12, Description = "removing ", IsComplete = true, Priority = "high", Title = "work on table " },
                        new { Id = 19, Description = "removing ", IsComplete = false, Priority = "high", Title = "estimate time" },
                        new { Id = 20, Description = "removing ", IsComplete = true, Priority = "major", Title = "blah blah" },
                        new { Id = 21, Description = "removing ", IsComplete = true, Priority = "high", Title = "yes no" },
                        new { Id = 22, Description = "removing ", IsComplete = false, Priority = "medium", Title = "update web apo" },
                        new { Id = 23, Description = "removing ", IsComplete = false, Priority = "medium", Title = "this is working" },
                        new { Id = 24, Description = "removing ", IsComplete = true, Priority = "low", Title = "ahan" }
                    );
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
