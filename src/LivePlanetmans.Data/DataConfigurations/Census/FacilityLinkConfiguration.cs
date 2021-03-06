using LivePlanetmans.Data.Models.Census;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlanetmans.Data.DataConfigurations.Census
{
    public class FacilityLinkConfiguration : IEntityTypeConfiguration<FacilityLink>
    {
        public void Configure(EntityTypeBuilder<FacilityLink> builder)
        {
            builder.ToTable("FacilityLink");

            builder.HasKey(e => e.Id);

            //builder.HasKey(e => new
            //{
            //    e.FacilityIdA,
            //    e.FacilityIdB
            //});

            builder.Ignore(e => e.FacilityA);
            builder.Ignore(e => e.FacilityB);
            builder.Ignore(e => e.Zone);
        }
    }
}
