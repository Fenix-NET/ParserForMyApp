using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParserForMyApp.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HddInterface",
                table: "Hdd",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfaceBandwidth",
                table: "Hdd",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HddInterface",
                table: "Hdd");

            migrationBuilder.DropColumn(
                name: "InterfaceBandwidth",
                table: "Hdd");
        }
    }
}
