using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Listen_Music.Persistance.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SingerName",
                table: "SingerFollowItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserSingerFollowId",
                table: "SingerFollowItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 10, 19, 11, 58, 531, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 10, 19, 11, 58, 535, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.CreateIndex(
                name: "IX_SingerFollowItems_UserSingerFollowId",
                table: "SingerFollowItems",
                column: "UserSingerFollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_SingerFollowItems_UserSingerFollows_UserSingerFollowId",
                table: "SingerFollowItems",
                column: "UserSingerFollowId",
                principalTable: "UserSingerFollows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingerFollowItems_UserSingerFollows_UserSingerFollowId",
                table: "SingerFollowItems");

            migrationBuilder.DropIndex(
                name: "IX_SingerFollowItems_UserSingerFollowId",
                table: "SingerFollowItems");

            migrationBuilder.DropColumn(
                name: "SingerName",
                table: "SingerFollowItems");

            migrationBuilder.DropColumn(
                name: "UserSingerFollowId",
                table: "SingerFollowItems");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 10, 18, 20, 1, 92, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 10, 18, 20, 1, 96, DateTimeKind.Local).AddTicks(3268));
        }
    }
}
