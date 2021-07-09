using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface ICharacterService
    {
        Task<Character> GetCharacter(string characterId);
        Task<Character> GetCharacterByName(string characterName);
        Task<OutfitMember> GetCharacterOutfit(string characterId);
    }
}
