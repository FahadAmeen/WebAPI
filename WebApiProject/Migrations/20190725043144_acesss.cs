using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class acesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessControl",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "denied");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessControl",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "access");
        }
    }
}
