using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library3.Migrations
{
    /// <inheritdoc />
    public partial class userinitemborro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemBorrowedBooks_Users_UserId",
                table: "ItemBorrowedBooks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ItemBorrowedBooks",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemBorrowedBooks_UserId",
                table: "ItemBorrowedBooks",
                newName: "IX_ItemBorrowedBooks_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "ItemBorrowedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBorrowedBooks_Users_UserID",
                table: "ItemBorrowedBooks",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemBorrowedBooks_Users_UserID",
                table: "ItemBorrowedBooks");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ItemBorrowedBooks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemBorrowedBooks_UserID",
                table: "ItemBorrowedBooks",
                newName: "IX_ItemBorrowedBooks_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ItemBorrowedBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBorrowedBooks_Users_UserId",
                table: "ItemBorrowedBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
