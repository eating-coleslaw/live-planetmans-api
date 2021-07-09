using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    class PlayerLoginConfiguration : IEntityTypeConfiguration<PlayerLogin>
    {
        public void Configure(EntityTypeBuilder<PlayerLogin> builder)
        {
            builder.ToTable("PlayerLogin");

            builder.HasKey(e => new
            {
                e.Timestamp,
                e.CharacterId
            });

            builder.Ignore(e => e.Character);
        }
    }
}
