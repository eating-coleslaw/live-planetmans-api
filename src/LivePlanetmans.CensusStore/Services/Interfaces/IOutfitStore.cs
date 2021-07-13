using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.CensusStore.Services
{
    public interface IOutfitStore
    {
        Task<Outfit> GetOutfitByIdAsync(string outfitId);
        Task<Outfit> GetOutfitByAlias(string alias);
        Task<IEnumerable<Character>> GetOutfitMembersByAlias(string alias);
        Task<OutfitMember> UpdateCharacterOutfitMembership(Character character);
        Task<IEnumerable<Outfit>> GetOutfitsByIdsAsync(IEnumerable<string> outfitIds);
    }
}
