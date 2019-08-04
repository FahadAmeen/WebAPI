using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class addedLoginTablev5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "eHCl155H53UdHMzLw+nKWA==");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "eHCl155H53UdHMzLw+nKWA==");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "eHCl155H53UdHMzLw+nKWA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
