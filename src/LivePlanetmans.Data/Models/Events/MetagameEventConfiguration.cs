using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class MetagameEventConfiguration : IEntityTypeConfiguration<MetagameEvent>
    {
        public void Configure(EntityTypeBuilder<MetagameEvent> builder)
        {
            builder.ToTable("MetagameEvent");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
