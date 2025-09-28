using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library3.Migrations
{
    /// <inheritdoc />
    public partial class error : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PenaltyAmount",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BorrowedBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "BorrowedBooks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PenaltyAmount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "BorrowedBooks");
        }
    }
}
