using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "HasPermission", "PageURL", "Pagename" },
                values: new object[] { 1, false, "http://localhost:4200/home", "home" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "HasPermission", "PageURL", "Pagename" },
                values: new object[] { 2, true, "http://localhost:4200", "movies" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "HasPermission", "PageURL", "Pagename" },
                values: new object[] { 3, false, "http://localhost:4200/ranking", "ranking" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
