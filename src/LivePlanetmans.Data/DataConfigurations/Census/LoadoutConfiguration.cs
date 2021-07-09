﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LivePlanetmans.Data.Models.Census;

namespace LivePlanetmans.Data.DataConfigurations.Census
{
    public class LoadoutConfiguration : IEntityTypeConfiguration<Loadout>
    {
        public void Configure(EntityTypeBuilder<Loadout> builder)
        {
            builder.ToTable("Loadout");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Ignore(e => e.Profile);
        }
    }
}
