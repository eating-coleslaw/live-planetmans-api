// Credit to Lampjaw

using static LivePlanetmans.Data.DbContextHelper;

namespace LivePlanetmans.Data
{
    public interface IDbContextHelper
    {
        DbContextFactory GetFactory();
    }
}
