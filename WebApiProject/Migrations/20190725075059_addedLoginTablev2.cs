using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class addedLoginTablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 1, "fahad@gmail.com", "123456" });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 2, "fahd@gmail.com", "123456" });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 3, "fahadameen@gmail.com", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
