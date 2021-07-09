using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace CensusStore.Services
{
    public interface ICharacterStore
    {
        Task<Character> GetCharacterAsync(string characterId);
        Task<Character> GetCharacterByNameAsync(string characterName);
        Task<OutfitMember> GetCharacterOutfitAsync(string characterId);
    }
}
