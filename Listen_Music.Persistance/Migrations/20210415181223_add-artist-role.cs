using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Listen_Music.Persistance.Migrations
{
    public partial class addartistrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 15, 22, 42, 23, 257, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 15, 22, 42, 23, 261, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[] { 3L, new DateTime(2021, 4, 15, 22, 42, 23, 261, DateTimeKind.Local).AddTicks(2729), false, "Artist", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 12, 13, 32, 54, 391, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 12, 13, 32, 54, 395, DateTimeKind.Local).AddTicks(6401));
        }
    }
}
