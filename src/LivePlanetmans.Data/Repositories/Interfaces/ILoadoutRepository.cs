using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface ILoadoutRepository
    {
        Task<IEnumerable<Loadout>> GetAllLoadoutsAsync();
        Task UpsertRangeAsync(IEnumerable<Loadout> entities);
    }
}
