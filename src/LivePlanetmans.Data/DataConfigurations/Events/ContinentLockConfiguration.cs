using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class ContinentLockConfiguration : IEntityTypeConfiguration<ContinentLock>
    {
        public void Configure(EntityTypeBuilder<ContinentLock> builder)
        {
            builder.ToTable("ContinentLock");

            builder.HasKey(e => new
            {
                e.Timestamp,
                e.WorldId,
                e.ZoneId
            });
        }
    }
}
