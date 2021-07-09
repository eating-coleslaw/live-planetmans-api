using LivePlanetmans.Data.Models.Census;
using LivePlanetmans.Shared.Planetside;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> GetAllProfiles();
        string GetPlanetsideClassDisplayName(PlanetsideClass planetsideClass);
        PlanetsideClass GetPlanetsideClassFromLoadoutId(int loadoutId);
        Task<Profile> GetProfileFromLoadoutId(int loadoutId);
    }
}
