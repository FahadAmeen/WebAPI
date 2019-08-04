using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class addedLoginTablev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "U2FsdGVkX19JTeB1MrejTIVWplVsIAx5bJ8SKvbdAjU=");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "U2FsdGVkX19JTeB1MrejTIVWplVsIAx5bJ8SKvbdAjU=");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "U2FsdGVkX19JTeB1MrejTIVWplVsIAx5bJ8SKvbdAjU=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
