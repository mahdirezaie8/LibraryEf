using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library3.Migrations
{
    /// <inheritdoc />
    public partial class editB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "BorrowedBooks");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "BorrowedBooks",
                newName: "CreatAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatAt",
                table: "BorrowedBooks",
                newName: "DateTime");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "BorrowedBooks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
