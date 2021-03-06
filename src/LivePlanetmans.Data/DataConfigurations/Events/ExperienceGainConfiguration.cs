using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlanetmans.Data.Models.Events;

namespace LivePlanetmans.Data.DataConfigurations.Events
{
    public class ExperienceGainConfiguration : IEntityTypeConfiguration<ExperienceGain>
    {
        public void Configure(EntityTypeBuilder<ExperienceGain> builder)
        {
            builder.ToTable("ExperienceGain");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => new { a.Timestamp, a.WorldId, a.ExperienceId, a.ZoneId });
            builder.HasIndex(a => new { a.Timestamp, a.CharacterId, a.ExperienceId });

            builder.Ignore(e => e.ActingCharacter);
            builder.Ignore(e => e.RecipientCharacter);
        }
    }
}
