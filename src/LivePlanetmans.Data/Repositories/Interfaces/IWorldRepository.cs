using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface IWorldRepository
    {
        Task<IEnumerable<World>> GetAllWorldsAsync();
        Task<World> GetWorldByIdAsync(int worldId);
        Task UpsertRangeAsync(IEnumerable<World> entities);
    }
}