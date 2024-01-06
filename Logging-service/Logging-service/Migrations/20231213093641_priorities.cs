using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logging_service.Migrations
{
    /// <inheritdoc />
    public partial class priorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Handled",
                table: "Logs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Handled",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Logs");
        }
    }
}
