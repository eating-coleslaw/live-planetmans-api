using LivePlanetmans.Data.Models.Census;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlanetmans.Data.DataConfigurations.Census
{
    public class MetagameEventStateConfiguration : IEntityTypeConfiguration<MetagameEventState>
    {
        public void Configure(EntityTypeBuilder<MetagameEventState> builder)
        {
            builder.ToTable("MetagameEventState");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
