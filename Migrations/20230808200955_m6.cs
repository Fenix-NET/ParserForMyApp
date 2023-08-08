using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParserForMyApp.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternalBays25",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalBays35",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxCoolerHeight",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxGpuLenght",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxPsuLength",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanelButton",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanelConnector",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsuFormat",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Case",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsbConnectors",
                table: "Case",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalBays25",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "InternalBays35",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "MaxCoolerHeight",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "MaxGpuLenght",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "MaxPsuLength",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "PanelButton",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "PanelConnector",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "PsuFormat",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "UsbConnectors",
                table: "Case");
        }
    }
}
