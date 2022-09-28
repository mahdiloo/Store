using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Persistence.Migrations
{
    public partial class tblusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 49, 25, 744, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 49, 25, 744, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 49, 25, 744, DateTimeKind.Local).AddTicks(7537));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 48, 17, 471, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 48, 17, 471, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 48, 17, 471, DateTimeKind.Local).AddTicks(3031));
        }
    }
}
