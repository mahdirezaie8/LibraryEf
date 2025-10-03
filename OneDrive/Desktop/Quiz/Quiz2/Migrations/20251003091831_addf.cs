using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz2.Migrations
{
    /// <inheritdoc />
    public partial class addf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaildedAttempts",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaildedAttempts",
                table: "Cards");
        }
    }
}
