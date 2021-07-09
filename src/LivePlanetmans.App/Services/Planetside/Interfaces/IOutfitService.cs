using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface IOutfitService
    {
        Task<Outfit> GetOutfit(string outfitId);
        Task<Outfit> GetOutfitByAlias(string alias);
        Task<IEnumerable<Character>> GetOutfitMembersByAlias(string alias);
        Task<OutfitMember> GetUpdatedCharacterOutfitMembership(Character character);

    }
}
