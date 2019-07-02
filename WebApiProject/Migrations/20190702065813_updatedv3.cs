using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Data.Migrations
{
    public partial class updatedv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }
    }
}
