using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class PlayerFacilityDefendConfiguration : IEntityTypeConfiguration<PlayerFacilityDefend>
    {
        public void Configure(EntityTypeBuilder<PlayerFacilityDefend> builder)
        {
            builder.ToTable("PlayerFacilityDefend");

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
