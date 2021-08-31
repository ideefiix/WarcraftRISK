using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WarcraftApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeTick",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastIncomeTick = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TickIntervall = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTick", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Income = table.Column<int>(type: "integer", nullable: false),
                    Cash = table.Column<int>(type: "integer", nullable: false),
                    Soldiers = table.Column<int>(type: "integer", nullable: false),
                    SoldierIncome = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    ownedTerritories = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnedById = table.Column<int>(type: "integer", nullable: true),
                    DoneScouting = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scout_Player_OwnedById",
                        column: x => x.OwnedById,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Defence = table.Column<int>(type: "integer", nullable: false),
                    WallLvl = table.Column<int>(type: "integer", nullable: false),
                    VillageLvl = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tile_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetedPlayerId = table.Column<int>(type: "integer", nullable: true),
                    ActionPlayerId = table.Column<int>(type: "integer", nullable: true),
                    TerritoryId = table.Column<int>(type: "integer", nullable: true),
                    expiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpyReport_Player_ActionPlayerId",
                        column: x => x.ActionPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpyReport_Player_TargetedPlayerId",
                        column: x => x.TargetedPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpyReport_Tile_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scout_OwnedById",
                table: "Scout",
                column: "OwnedById");

            migrationBuilder.CreateIndex(
                name: "IX_SpyReport_ActionPlayerId",
                table: "SpyReport",
                column: "ActionPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpyReport_TargetedPlayerId",
                table: "SpyReport",
                column: "TargetedPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpyReport_TerritoryId",
                table: "SpyReport",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_PlayerId",
                table: "Tile",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeTick");

            migrationBuilder.DropTable(
                name: "Scout");

            migrationBuilder.DropTable(
                name: "SpyReport");

            migrationBuilder.DropTable(
                name: "Tile");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
