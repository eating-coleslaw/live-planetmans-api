using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterByIdAsync(string characterId);
        Task<Character> GetCharacterByNameAsync(string characterName);
        Task<Character> UpsertAsync(Character entity);
    }
}
