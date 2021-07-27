using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Listen_Music.Persistance.Migrations
{
    public partial class playlistfollow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPlayListFollows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlayListFollows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlayListFollows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayListFollowItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayListsId = table.Column<long>(type: "bigint", nullable: false),
                    PlayListName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPlayListFollowId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListFollowItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayListFollowItems_PlayLists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListFollowItems_UserPlayListFollows_UserPlayListFollowId",
                        column: x => x.UserPlayListFollowId,
                        principalTable: "UserPlayListFollows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PlayListFollowItems_PlayListsId",
                table: "PlayListFollowItems",
                column: "PlayListsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListFollowItems_UserPlayListFollowId",
                table: "PlayListFollowItems",
                column: "UserPlayListFollowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlayListFollows_UserId",
                table: "UserPlayListFollows",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListFollowItems");

            migrationBuilder.DropTable(
                name: "UserPlayListFollows");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 12, 11, 35, 23, 58, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 12, 11, 35, 23, 62, DateTimeKind.Local).AddTicks(2062));
        }
    }
}
