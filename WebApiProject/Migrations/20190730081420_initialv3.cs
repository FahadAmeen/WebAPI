using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class initialv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyLog",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyLog",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MyLog",
                keyColumn: "Id",
                keyValue: 3);

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
            migrationBuilder.InsertData(
                table: "MyLog",
                columns: new[] { "Id", "Created", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "25/07/2019 5:36:56 PM", "Not Found 12", " Warn " },
                    { 2, "25/07/2019 5:37:33 PM", "Not Found 200", " Warn " },
                    { 3, "25/07/2019 5:37:36 PM", "System.DivideByZeroExceptionAttemptedtodividebyzerat..", " Error " }
                });

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
    }
}
