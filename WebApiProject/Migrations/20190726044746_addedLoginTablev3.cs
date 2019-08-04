using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class addedLoginTablev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "U2FsdGVkX1+amyr7tiQthFJAkQBjRSGat/sMU3HsKgE=");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "U2FsdGVkX1+amyr7tiQthFJAkQBjRSGat/sMU3HsKgE=");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "U2FsdGVkX1+amyr7tiQthFJAkQBjRSGat/sMU3HsKgE=");

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 4, "fahadj@gmail.com", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "123456");
        }
    }
}
