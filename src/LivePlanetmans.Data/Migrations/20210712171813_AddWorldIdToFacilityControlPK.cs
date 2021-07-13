using Microsoft.EntityFrameworkCore.Migrations;

namespace LivePlanetmans.Data.Migrations
{
    public partial class AddWorldIdToFacilityControlPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacilityControl",
                table: "FacilityControl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacilityControl",
                table: "FacilityControl",
                columns: new[] { "Timestamp", "FacilityId", "WorldId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacilityControl",
                table: "FacilityControl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacilityControl",
                table: "FacilityControl",
                columns: new[] { "Timestamp", "FacilityId" });
        }
    }
}
