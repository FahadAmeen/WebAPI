using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "serial", "SiteName", "SiteUrl", "access" },
                values: new object[] { 1, "Table", "http://localhost:4200/table", true });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "serial", "SiteName", "SiteUrl", "access" },
                values: new object[] { 2, "Input", "http://localhost:4200/input", false });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "serial", "SiteName", "SiteUrl", "access" },
                values: new object[] { 3, "Edit", "http://localhost:4200/edit", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "serial",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "serial",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "serial",
                keyValue: 3);
        }
    }
}
