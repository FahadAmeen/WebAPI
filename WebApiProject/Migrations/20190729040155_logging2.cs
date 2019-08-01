﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class logging2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserLogin");

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 1,
                column: "SPassword",
                value: new byte[] { 18, 69, 13, 228, 203, 34, 233, 132, 180, 67, 231, 158, 207, 251, 95, 204 });

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 2,
                column: "SPassword",
                value: new byte[] { 107, 227, 108, 3, 238, 90, 23, 11, 163, 75, 245, 104, 120, 153, 41, 165 });

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 3,
                column: "SPassword",
                value: new byte[] { 145, 134, 24, 6, 93, 72, 139, 45, 135, 150, 116, 211, 135, 210, 30, 154 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserLogin",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Password", "SPassword" },
                values: new object[] { "aaaa", new byte[] { 18, 69, 13, 228, 203, 34, 233, 132, 180, 67, 231, 158, 207, 251, 95, 204 } });

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "Password", "SPassword" },
                values: new object[] { "bbbb", new byte[] { 107, 227, 108, 3, 238, 90, 23, 11, 163, 75, 245, 104, 120, 153, 41, 165 } });

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "Password", "SPassword" },
                values: new object[] { "cccc", new byte[] { 145, 134, 24, 6, 93, 72, 139, 45, 135, 150, 116, 211, 135, 210, 30, 154 } });
        }
    }
}
