using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarcraftApi.Migrations
{
    public partial class ExpiryDateToSpyReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conquered",
                table: "Tile");

            migrationBuilder.AddColumn<DateTime>(
                name: "expiryDate",
                table: "SpyReport",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expiryDate",
                table: "SpyReport");

            migrationBuilder.AddColumn<DateTime>(
                name: "Conquered",
                table: "Tile",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
