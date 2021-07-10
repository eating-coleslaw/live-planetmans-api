using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LivePlanetmans.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContinentLock",
                columns: table => new
                {
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MetagameEventId = table.Column<int>(type: "integer", nullable: true),
                    TriggeringFaction = table.Column<int>(type: "integer", nullable: true),
                    PopulationVs = table.Column<float>(type: "real", nullable: true),
                    PopulationNc = table.Column<float>(type: "real", nullable: true),
                    PopulationTr = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentLock", x => new { x.Timestamp, x.WorldId, x.ZoneId });
                });

            migrationBuilder.CreateTable(
                name: "ContinentUnlock",
                columns: table => new
                {
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MetagameEventId = table.Column<int>(type: "integer", nullable: true),
                    TriggeringFaction = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentUnlock", x => new { x.Timestamp, x.WorldId, x.ZoneId });
                });

            migrationBuilder.CreateTable(
                name: "Death",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AttackerCharacterId = table.Column<string>(type: "text", nullable: false),
                    VictimCharacterId = table.Column<string>(type: "text", nullable: false),
                    DeathType = table.Column<int>(type: "integer", nullable: false),
                    AttackerLoadoutId = table.Column<int>(type: "integer", nullable: true),
                    AttackerFactionId = table.Column<int>(type: "integer", nullable: true),
                    VictimLoadoutId = table.Column<int>(type: "integer", nullable: true),
                    VictimFactionId = table.Column<int>(type: "integer", nullable: true),
                    IsHeadshot = table.Column<bool>(type: "boolean", nullable: false),
                    WeaponId = table.Column<int>(type: "integer", nullable: true),
                    AttackerVehicleId = table.Column<int>(type: "integer", nullable: true),
                    ZoneId = table.Column<int>(type: "integer", nullable: true),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Death", x => new { x.Timestamp, x.AttackerCharacterId, x.VictimCharacterId });
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Xp = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceGain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<string>(type: "text", nullable: false),
                    ExperienceId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    LoadoutId = table.Column<int>(type: "integer", nullable: true),
                    OtherId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceGain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityControl",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    ControlType = table.Column<int>(type: "integer", nullable: false),
                    OldFactionId = table.Column<int>(type: "integer", nullable: true),
                    NewFactionId = table.Column<int>(type: "integer", nullable: true),
                    ZoneId = table.Column<int>(type: "integer", nullable: true),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityControl", x => new { x.Timestamp, x.FacilityId });
                });

            migrationBuilder.CreateTable(
                name: "FacilityLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FacilityIdA = table.Column<int>(type: "integer", nullable: false),
                    FacilityIdB = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    Desription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true),
                    CodeTag = table.Column<string>(type: "text", nullable: true),
                    UserSelectable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ItemTypeId = table.Column<int>(type: "integer", nullable: true),
                    ItemCategoryId = table.Column<int>(type: "integer", nullable: true),
                    IsVehicleWeapon = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FactionId = table.Column<int>(type: "integer", nullable: true),
                    MaxStackSize = table.Column<int>(type: "integer", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsWeaponCategory = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loadout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    FactionId = table.Column<int>(type: "integer", nullable: false),
                    CodeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loadout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    FacilityName = table.Column<string>(type: "text", nullable: true),
                    FacilityTypeId = table.Column<int>(type: "integer", nullable: false),
                    FacilityType = table.Column<string>(type: "text", nullable: true),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    IsDeprecated = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRegion", x => new { x.Id, x.FacilityId });
                });

            migrationBuilder.CreateTable(
                name: "MetagameEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: true),
                    InstanceId = table.Column<int>(type: "integer", nullable: true),
                    MetagameEventId = table.Column<int>(type: "integer", nullable: true),
                    MetagameEventState = table.Column<string>(type: "text", nullable: true),
                    ExperienceBonus = table.Column<int>(type: "integer", nullable: true),
                    ZoneControlVs = table.Column<float>(type: "real", nullable: true),
                    ZoneControlNc = table.Column<float>(type: "real", nullable: true),
                    ZoneControlTr = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetagameEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetagameEventCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: true),
                    ExperienceBonus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetagameEventCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetagameEventState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetagameEventState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFacilityCapture",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "text", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    OutfitId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFacilityCapture", x => new { x.Timestamp, x.CharacterId, x.FacilityId });
                });

            migrationBuilder.CreateTable(
                name: "PlayerFacilityDefend",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "text", nullable: false),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false),
                    OutfitId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFacilityDefend", x => new { x.Timestamp, x.CharacterId, x.FacilityId });
                });

            migrationBuilder.CreateTable(
                name: "PlayerLogin",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLogin", x => new { x.Timestamp, x.CharacterId });
                });

            migrationBuilder.CreateTable(
                name: "PlayerLogout",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLogout", x => new { x.Timestamp, x.CharacterId });
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ProfileTypeId = table.Column<int>(type: "integer", nullable: false),
                    FactionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdaterScheduler",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdaterScheduler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<int>(type: "integer", nullable: true),
                    CostResourceId = table.Column<int>(type: "integer", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDestruction",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AttackerCharacterId = table.Column<string>(type: "text", nullable: false),
                    VictimCharacterId = table.Column<string>(type: "text", nullable: false),
                    VictimVehicleId = table.Column<int>(type: "integer", nullable: false),
                    DeathType = table.Column<int>(type: "integer", nullable: false),
                    AttackerVehicleId = table.Column<int>(type: "integer", nullable: true),
                    WeaponId = table.Column<int>(type: "integer", nullable: true),
                    IsVehicleWeapon = table.Column<bool>(type: "boolean", nullable: true),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: true),
                    FacilityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDestruction", x => new { x.Timestamp, x.AttackerCharacterId, x.VictimCharacterId, x.VictimVehicleId });
                });

            migrationBuilder.CreateTable(
                name: "World",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_World", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    HexSize = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGain_Timestamp_CharacterId_ExperienceId",
                table: "ExperienceGain",
                columns: new[] { "Timestamp", "CharacterId", "ExperienceId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGain_Timestamp_WorldId_ExperienceId_ZoneId",
                table: "ExperienceGain",
                columns: new[] { "Timestamp", "WorldId", "ExperienceId", "ZoneId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContinentLock");

            migrationBuilder.DropTable(
                name: "ContinentUnlock");

            migrationBuilder.DropTable(
                name: "Death");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "ExperienceGain");

            migrationBuilder.DropTable(
                name: "FacilityControl");

            migrationBuilder.DropTable(
                name: "FacilityLink");

            migrationBuilder.DropTable(
                name: "FacilityType");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "Loadout");

            migrationBuilder.DropTable(
                name: "MapRegion");

            migrationBuilder.DropTable(
                name: "MetagameEvent");

            migrationBuilder.DropTable(
                name: "MetagameEventCategory");

            migrationBuilder.DropTable(
                name: "MetagameEventState");

            migrationBuilder.DropTable(
                name: "PlayerFacilityCapture");

            migrationBuilder.DropTable(
                name: "PlayerFacilityDefend");

            migrationBuilder.DropTable(
                name: "PlayerLogin");

            migrationBuilder.DropTable(
                name: "PlayerLogout");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "UpdaterScheduler");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleDestruction");

            migrationBuilder.DropTable(
                name: "World");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
