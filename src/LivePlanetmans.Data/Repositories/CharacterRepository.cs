using LivePlanetmans.Data.Models.Census;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IDbContextHelper _dbContextHelper;

        public CharacterRepository(IDbContextHelper dbContextHelper)
        {
            _dbContextHelper = dbContextHelper;
        }

        public async Task<Character> GetCharacterByIdAsync(string characterId)
        {
            using var factory = _dbContextHelper.GetFactory();
            var dbContext = factory.GetDbContext();

            return await dbContext.Characters.SingleOrDefaultAsync(c => c.Id == characterId);
        }

        public async Task<Character> GetCharacterByNameAsync(string characterName)
        {
            using var factory = _dbContextHelper.GetFactory();
            var dbContext = factory.GetDbContext();

            return await dbContext.Characters.SingleOrDefaultAsync(c => c.Name == characterName);
        }

        public async Task<Character> UpsertAsync(Character entity)
        {
            using var factory = _dbContextHelper.GetFactory();
            var dbContext = factory.GetDbContext();

            await dbContext.Characters.UpsertAsync(entity, a => a.Id == entity.Id);

            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
