using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    PageUrl = table.Column<string>(nullable: true),
                    isAccessible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Name);
                });

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: new byte[] { 66, 145, 205, 222, 149, 121, 112, 56, 178, 91, 82, 92, 149, 28, 154, 233 });

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
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.UpdateData(
                table: "Login",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: new byte[] { 66, 145, 205, 222, 149, 121, 112, 56, 178, 91, 82, 92, 149, 28, 154, 233 });

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
