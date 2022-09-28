using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Persistence.Migrations
{
    public partial class edituser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 44, 14, 383, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 44, 14, 383, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 9, 23, 20, 44, 14, 383, DateTimeKind.Local).AddTicks(3940));
        }
    }
}
