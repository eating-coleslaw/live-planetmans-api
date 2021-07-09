using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.CensusStore.Services
{
    public interface IWorldStore : IUpdateable
    {
        Task<IEnumerable<World>> GetAllWorldsAsync();
        Task<World> GetWorldByIdAsync(int worldId);
    }
}
