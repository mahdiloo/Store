using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Persistence.Migrations
{
    public partial class edittblpays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 43, 17, 877, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 43, 17, 877, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 43, 17, 877, DateTimeKind.Local).AddTicks(9414));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 38, 16, 961, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 38, 16, 961, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 24, 0, 38, 16, 961, DateTimeKind.Local).AddTicks(371));
        }
    }
}
