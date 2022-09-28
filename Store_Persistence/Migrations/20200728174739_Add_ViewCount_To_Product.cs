using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bugeto_Store.Persistence.Migrations
{
    public partial class Add_ViewCount_To_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 28, 22, 17, 38, 682, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 28, 22, 17, 38, 687, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 28, 22, 17, 38, 687, DateTimeKind.Local).AddTicks(9401));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 6, 17, 45, 44, 513, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 6, 17, 45, 44, 518, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2020, 7, 6, 17, 45, 44, 518, DateTimeKind.Local).AddTicks(1042));
        }
    }
}
