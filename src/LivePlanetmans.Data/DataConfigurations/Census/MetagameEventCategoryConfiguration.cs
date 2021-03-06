using LivePlanetmans.Data.Models.Census;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlanetmans.Data.DataConfigurations.Census
{
    public class MetagameEventCategoryConfiguration : IEntityTypeConfiguration<MetagameEventCategory>
    {
        public void Configure(EntityTypeBuilder<MetagameEventCategory> builder)
        {
            builder.ToTable("MetagameEventCategory");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
