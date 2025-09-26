using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library3.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowedBooksId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBorrowedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBorrowedBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks",
                column: "ItemBorrowedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBorrowedBooks_UserId",
                table: "ItemBorrowedBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_ItemBorrowedBooks_ItemBorrowedBookId",
                table: "BorrowedBooks",
                column: "ItemBorrowedBookId",
                principalTable: "ItemBorrowedBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DateTime",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "ItemBorrowedBookId",
                table: "BorrowedBooks");

            migrationBuilder.AddColumn<int>(
                name: "BorrowedBooksId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
