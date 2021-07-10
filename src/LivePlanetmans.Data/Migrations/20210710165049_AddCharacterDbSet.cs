using Microsoft.EntityFrameworkCore.Migrations;

namespace LivePlanetmans.Data.Migrations
{
    public partial class AddCharacterDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    OutfitId = table.Column<string>(type: "text", nullable: true),
                    OutfitAlias = table.Column<string>(type: "text", nullable: true),
                    OutfitAliasLower = table.Column<string>(type: "text", nullable: true),
                    FactionId = table.Column<int>(type: "integer", nullable: false),
                    TitleId = table.Column<int>(type: "integer", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    BattleRank = table.Column<int>(type: "integer", nullable: false),
                    BattleRankPercentToNext = table.Column<int>(type: "integer", nullable: false),
                    CertsEarned = table.Column<int>(type: "integer", nullable: false),
                    PrestigeLevel = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
