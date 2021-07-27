using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Listen_Music.Persistance.Migrations
{
    public partial class genrefollow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGenreFollows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenreFollows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGenreFollows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreFollowItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserGenreFollowId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreFollowItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreFollowItems_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreFollowItems_UserGenreFollows_UserGenreFollowId",
                        column: x => x.UserGenreFollowId,
                        principalTable: "UserGenreFollows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GenreFollowItems_GenreId",
                table: "GenreFollowItems",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreFollowItems_UserGenreFollowId",
                table: "GenreFollowItems",
                column: "UserGenreFollowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenreFollows_UserId",
                table: "UserGenreFollows",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreFollowItems");

            migrationBuilder.DropTable(
                name: "UserGenreFollows");

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
        }
    }
}
