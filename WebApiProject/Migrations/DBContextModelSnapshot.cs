﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiProject.Data;
using DataAccess;
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

            modelBuilder.Entity("WebApiProject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
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
