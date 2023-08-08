using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParserForMyApp.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Ssd",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Ssd",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SsdResource",
                table: "Ssd",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Ssd");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Ssd");

            migrationBuilder.DropColumn(
                name: "SsdResource",
                table: "Ssd");
        }
    }
}
