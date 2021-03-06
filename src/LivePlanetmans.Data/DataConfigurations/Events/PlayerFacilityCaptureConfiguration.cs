using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class PlayerFacilityCaptureConfiguration : IEntityTypeConfiguration<PlayerFacilityCapture>
    {
        public void Configure(EntityTypeBuilder<PlayerFacilityCapture> builder)
        {
            builder.ToTable("PlayerFacilityCapture");

            builder.HasKey(e => new
            {
                e.Timestamp,
                e.CharacterId,
                e.FacilityId
            });

            builder.Ignore(e => e.Character);
            builder.Ignore(e => e.Facility);
        }
    }
}
