using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserLogin",
                columns: new[] { "id", "Access", "Password", "email" },
                values: new object[] { 1, "true", "aaaa", "sahar@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserLogin",
                columns: new[] { "id", "Access", "Password", "email" },
                values: new object[] { 2, "true", "bbbb", "sana@hotmail.com" });

            migrationBuilder.InsertData(
                table: "UserLogin",
                columns: new[] { "id", "Access", "Password", "email" },
                values: new object[] { 3, "true", "cccc", "rida@yahoo.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
