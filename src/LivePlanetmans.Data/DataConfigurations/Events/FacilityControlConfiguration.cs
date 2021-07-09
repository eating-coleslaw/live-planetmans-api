using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class FacilityControlConfiguration : IEntityTypeConfiguration<FacilityControl>
    {
        public void Configure(EntityTypeBuilder<FacilityControl> builder)
        {
            builder.ToTable("FacilityControl");

            builder.HasKey(e => new
            {
                e.Timestamp,
                e.FacilityId,
            });

            builder.Property(e => e.Points).HasDefaultValue(0);

            builder.Ignore(e => e.Zone);
            builder.Ignore(e => e.World);
        }
    }
}
