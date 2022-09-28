using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Persistence.Migrations
{
    public partial class updatetblhomepage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_homePageImages",
                table: "homePageImages");

            migrationBuilder.RenameTable(
                name: "homePageImages",
                newName: "HomePageImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageImages",
                table: "HomePageImages",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageImages",
                table: "HomePageImages");

            migrationBuilder.RenameTable(
                name: "HomePageImages",
                newName: "homePageImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_homePageImages",
                table: "homePageImages",
                column: "Id");
        }
    }
}
