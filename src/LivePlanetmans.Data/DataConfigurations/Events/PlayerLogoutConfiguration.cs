using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class PlayerLogoutConfiguration : IEntityTypeConfiguration<PlayerLogout>
    {
        public void Configure(EntityTypeBuilder<PlayerLogout> builder)
        {
            builder.ToTable("PlayerLogout");

            builder.HasKey(e => new
            {
                e.Timestamp,
                e.CharacterId
            });

            builder.Ignore(e => e.Character);
        }
    }
}
