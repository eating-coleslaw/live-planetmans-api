﻿// <auto-generated />
using System;
using LivePlanetmans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LivePlanetmans.Data.Migrations
{
    [DbContext(typeof(PlanetmansDbContext))]
    [Migration("20210709184449_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Experience", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<float>("Xp")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.FacilityLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Desription")
                        .HasColumnType("text");

                    b.Property<int>("FacilityIdA")
                        .HasColumnType("integer");

                    b.Property<int>("FacilityIdB")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FacilityLink");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.FacilityType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FacilityType");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Faction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CodeTag")
                        .HasColumnType("text");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("UserSelectable")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Faction");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Item", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("FactionId")
                        .HasColumnType("integer");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsVehicleWeapon")
                        .HasColumnType("boolean");

                    b.Property<int?>("ItemCategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("ItemTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxStackSize")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsWeaponCategory")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ItemCategory");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Loadout", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CodeName")
                        .HasColumnType("text");

                    b.Property<int>("FactionId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Loadout");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.MapRegion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<string>("FacilityName")
                        .HasColumnType("text");

                    b.Property<string>("FacilityType")
                        .HasColumnType("text");

                    b.Property<int>("FacilityTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeprecated")
                        .HasColumnType("boolean");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id", "FacilityId");

                    b.ToTable("MapRegion");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.MetagameEventCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ExperienceBonus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MetagameEventCategory");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.MetagameEventState", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MetagameEventState");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Profile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("FactionId")
                        .HasColumnType("integer");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ProfileTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Cost")
                        .HasColumnType("integer");

                    b.Property<int?>("CostResourceId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.World", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("World");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Census.Zone", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("HexSize")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.ContinentLock", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.Property<int?>("MetagameEventId")
                        .HasColumnType("integer");

                    b.Property<float?>("PopulationNc")
                        .HasColumnType("real");

                    b.Property<float?>("PopulationTr")
                        .HasColumnType("real");

                    b.Property<float?>("PopulationVs")
                        .HasColumnType("real");

                    b.Property<int?>("TriggeringFaction")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "WorldId", "ZoneId");

                    b.ToTable("ContinentLock");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.ContinentUnlock", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.Property<int?>("MetagameEventId")
                        .HasColumnType("integer");

                    b.Property<int?>("TriggeringFaction")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "WorldId", "ZoneId");

                    b.ToTable("ContinentUnlock");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.Death", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AttackerCharacterId")
                        .HasColumnType("text");

                    b.Property<string>("VictimCharacterId")
                        .HasColumnType("text");

                    b.Property<int?>("AttackerFactionId")
                        .HasColumnType("integer");

                    b.Property<int?>("AttackerLoadoutId")
                        .HasColumnType("integer");

                    b.Property<int?>("AttackerVehicleId")
                        .HasColumnType("integer");

                    b.Property<int>("DeathType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsHeadshot")
                        .HasColumnType("boolean");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int?>("VictimFactionId")
                        .HasColumnType("integer");

                    b.Property<int?>("VictimLoadoutId")
                        .HasColumnType("integer");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("integer");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "AttackerCharacterId", "VictimCharacterId");

                    b.ToTable("Death");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.ExperienceGain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("CharacterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("integer");

                    b.Property<int?>("LoadoutId")
                        .HasColumnType("integer");

                    b.Property<string>("OtherId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Timestamp", "CharacterId", "ExperienceId");

                    b.HasIndex("Timestamp", "WorldId", "ExperienceId", "ZoneId");

                    b.ToTable("ExperienceGain");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.FacilityControl", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<int>("ControlType")
                        .HasColumnType("integer");

                    b.Property<int?>("NewFactionId")
                        .HasColumnType("integer");

                    b.Property<int?>("OldFactionId")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "FacilityId");

                    b.ToTable("FacilityControl");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.MetagameEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ExperienceBonus")
                        .HasColumnType("integer");

                    b.Property<int?>("InstanceId")
                        .HasColumnType("integer");

                    b.Property<int?>("MetagameEventId")
                        .HasColumnType("integer");

                    b.Property<string>("MetagameEventState")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<float?>("ZoneControlNc")
                        .HasColumnType("real");

                    b.Property<float?>("ZoneControlTr")
                        .HasColumnType("real");

                    b.Property<float?>("ZoneControlVs")
                        .HasColumnType("real");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MetagameEvent");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.PlayerFacilityCapture", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CharacterId")
                        .HasColumnType("text");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<string>("OutfitId")
                        .HasColumnType("text");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "CharacterId", "FacilityId");

                    b.ToTable("PlayerFacilityCapture");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.PlayerFacilityDefend", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CharacterId")
                        .HasColumnType("text");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<string>("OutfitId")
                        .HasColumnType("text");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "CharacterId", "FacilityId");

                    b.ToTable("PlayerFacilityDefend");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.PlayerLogin", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CharacterId")
                        .HasColumnType("text");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "CharacterId");

                    b.ToTable("PlayerLogin");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.PlayerLogout", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CharacterId")
                        .HasColumnType("text");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "CharacterId");

                    b.ToTable("PlayerLogout");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.Events.VehicleDestruction", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AttackerCharacterId")
                        .HasColumnType("text");

                    b.Property<string>("VictimCharacterId")
                        .HasColumnType("text");

                    b.Property<int>("VictimVehicleId")
                        .HasColumnType("integer");

                    b.Property<int?>("AttackerVehicleId")
                        .HasColumnType("integer");

                    b.Property<int>("DeathType")
                        .HasColumnType("integer");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsVehicleWeapon")
                        .HasColumnType("boolean");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("integer");

                    b.Property<int>("WorldId")
                        .HasColumnType("integer");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Timestamp", "AttackerCharacterId", "VictimCharacterId", "VictimVehicleId");

                    b.ToTable("VehicleDestruction");
                });

            modelBuilder.Entity("LivePlanetmans.Data.Models.UpdaterScheduler", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("UpdaterScheduler");
                });
#pragma warning restore 612, 618
        }
    }
}
