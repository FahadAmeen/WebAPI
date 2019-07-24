using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class updatepermissio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permission",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Permission",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name", "PageUrl", "isAccessible" },
                values: new object[,]
                {
                    { 1, "Welcome Page", "http://localhost:4200/home", false },
                    { 2, "Login Page", "http://localhost:4200/login", true },
                    { 3, "Todo Page", "http://localhost:4200/todoitems", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Permission");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permission",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Name");

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
