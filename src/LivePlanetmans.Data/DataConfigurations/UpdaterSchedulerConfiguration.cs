// Credit to Lampjaw

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LivePlanetmans.Data.Models;

namespace LivePlanetmans.Data.DataConfigurations
{
    class UpdaterSchedulerConfiguration : IEntityTypeConfiguration<UpdaterScheduler>
    {
        public void Configure(EntityTypeBuilder<UpdaterScheduler> builder)
        {
            builder.ToTable("UpdaterScheduler");

            builder.HasKey(a => a.Id);
        }
    }
}
