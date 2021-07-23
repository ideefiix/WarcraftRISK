using Microsoft.EntityFrameworkCore.Migrations;

namespace WarcraftApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Income = table.Column<int>(type: "INTEGER", nullable: false),
                    Cash = table.Column<int>(type: "INTEGER", nullable: false),
                    Minions = table.Column<int>(type: "INTEGER", nullable: false),
                    Spawner = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
