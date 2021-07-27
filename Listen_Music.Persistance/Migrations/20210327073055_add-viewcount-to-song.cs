using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Listen_Music.Persistance.Migrations
{
    public partial class addviewcounttosong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewConut",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 3, 27, 12, 0, 54, 182, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 3, 27, 12, 0, 54, 186, DateTimeKind.Local).AddTicks(8084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewConut",
                table: "Songs");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 3, 23, 0, 56, 19, 411, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 3, 23, 0, 56, 19, 415, DateTimeKind.Local).AddTicks(7805));
        }
    }
}
