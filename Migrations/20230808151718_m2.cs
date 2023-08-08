using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParserForMyApp.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectorGpu",
                table: "Psu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectorMotherboard",
                table: "Psu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Herz",
                table: "Psu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LenghtCable",
                table: "Psu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Psu",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectorGpu",
                table: "Psu");

            migrationBuilder.DropColumn(
                name: "ConnectorMotherboard",
                table: "Psu");

            migrationBuilder.DropColumn(
                name: "Herz",
                table: "Psu");

            migrationBuilder.DropColumn(
                name: "LenghtCable",
                table: "Psu");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Psu");
        }
    }
}
