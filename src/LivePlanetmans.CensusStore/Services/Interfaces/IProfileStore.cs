using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.CensusStore.Services
{
    public interface IProfileStore : IUpdateable
    {
        Task<IEnumerable<Loadout>> GetAllLoadoutsAsync();
        Task<IEnumerable<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileFromLoadoutIdAsync(int loadoutId);
    }
}
