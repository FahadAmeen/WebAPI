using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class userUpdates3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "UserEmail" },
                values: new object[] { new byte[] { 66, 145, 205, 222, 149, 121, 112, 56, 178, 91, 82, 92, 149, 28, 154, 233 }, "sej@ciklum.com" });

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: new byte[] { 15, 154, 179, 67, 101, 118, 152, 215, 18, 220, 20, 210, 161, 5, 150, 209 });

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: new byte[] { 222, 181, 24, 67, 220, 146, 43, 164, 232, 212, 154, 113, 246, 185, 241, 13 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "UserEmail" },
                values: new object[] { new byte[] { 66, 145, 205, 222, 149, 121, 112, 56, 178, 91, 82, 92, 149, 28, 154, 233 }, "sahar@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: new byte[] { 15, 154, 179, 67, 101, 118, 152, 215, 18, 220, 20, 210, 161, 5, 150, 209 });

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: new byte[] { 222, 181, 24, 67, 220, 146, 43, 164, 232, 212, 154, 113, 246, 185, 241, 13 });
        }
    }
}
