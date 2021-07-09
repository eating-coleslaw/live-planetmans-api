using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface IFactionService
    {
        Task<IEnumerable<Faction>> GetAllFactions();
        Task<Faction> GetFaction(int factionId);
    }
}
