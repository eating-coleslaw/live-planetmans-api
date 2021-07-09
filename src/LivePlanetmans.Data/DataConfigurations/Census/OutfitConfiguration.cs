﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LivePlanetmans.Data.Models.Census;

namespace LivePlanetmans.Data.DataConfigurations.Census

{
    public class OutfitConfiguration : IEntityTypeConfiguration<Outfit>
    {
        public void Configure(EntityTypeBuilder<Outfit> builder)
        {
            builder.ToTable("Outfit");

            builder.HasKey(e => e.Id);

            builder
                .Ignore(e => e.Faction)
                .Ignore(e => e.World)
                .Ignore(e => e.LeaderCharacter);
        }
    }
}
