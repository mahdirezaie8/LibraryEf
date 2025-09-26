using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library3.Migrations
{
    /// <inheritdoc />
    public partial class deleteitemb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_ItemBorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "ItemBorrowedBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "ItemBorrowedBookId",
                table: "BorrowedBooks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "BorrowedBooks");

            migrationBuilder.AddColumn<int>(
                name: "ItemBorrowedBookId",
                table: "BorrowedBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemBorrowedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBorrowedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBorrowedBooks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks",
                column: "ItemBorrowedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBorrowedBooks_UserID",
                table: "ItemBorrowedBooks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_ItemBorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks",
                column: "ItemBorrowedBookId",
                principalTable: "ItemBorrowedBooks",
                principalColumn: "Id");
        }
    }
}
