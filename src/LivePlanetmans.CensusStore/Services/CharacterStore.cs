using LivePlanetmans.CensusServices;
using LivePlanetmans.CensusServices.Models;
using LivePlanetmans.Data.Models.Census;
using LivePlanetmans.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LivePlanetmans.CensusStore.Services
{
    public class CharacterStore : ICharacterStore
    {
        private readonly IOutfitStore _outfitStore;
        private readonly ICharacterRepository _characterRepository;
        private readonly CensusCharacter _censusCharacter;
        private readonly ILogger<CharacterStore> _logger;

        public CharacterStore(IOutfitStore outfitStore, ICharacterRepository characterRepository, CensusCharacter censusCharacter, ILogger<CharacterStore> logger)
        {
            _outfitStore = outfitStore;
            _characterRepository = characterRepository;
            _censusCharacter = censusCharacter;
            _logger = logger;
        }

        public async Task<Character> GetCharacterAsync(string characterId)
        {
            try
            {
                var censusEntity = await _characterRepository.GetCharacterByIdAsync(characterId);

                if (censusEntity != null)
                {
                    return censusEntity;
                }

                var character = await _censusCharacter.GetCharacter(characterId);
            
                if (character == null)
                {
                    return null;
                }
            
                censusEntity = ConvertToDbModel(character);

                await _characterRepository.UpsertAsync(censusEntity);

                return censusEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to get character {characterId}: {ex}");

                return null;
            }
        }

        public async Task<Character> GetCharacterByNameAsync(string characterName)
        {
            var censusEntity = await _characterRepository.GetCharacterByNameAsync(characterName);

            if (censusEntity != null)
            {
                return censusEntity;
            }
            
            var character = await _censusCharacter.GetCharacterByName(characterName);

            if (character == null)
            {
                return null;
            }

            censusEntity = ConvertToDbModel(character);

            await _characterRepository.UpsertAsync(censusEntity);

            return censusEntity;
        }

        public async Task<OutfitMember> GetCharacterOutfitAsync(string characterId)
        {
            var character = await GetCharacterAsync(characterId);
            if (character == null)
            {
                return null;
            }

            return await _outfitStore.UpdateCharacterOutfitMembership(character);
        }

        private static Character ConvertToDbModel(CensusCharacterModel censusModel)
        {
            bool isOnline;
            
            if (int.TryParse(censusModel.OnlineStatus, out int onlineStatus))
            {
                isOnline = onlineStatus > 0;
            }
            else // "service_unavailable"
            {
                isOnline = false;
            }

            return new Character
            {
                Id = censusModel.CharacterId,
                Name = censusModel.Name.First,
                FactionId = censusModel.FactionId,
                TitleId = censusModel.TitleId,
                WorldId = censusModel.WorldId,
                BattleRank = censusModel.BattleRank.Value,
                BattleRankPercentToNext = censusModel.BattleRank.PercentToNext,
                CertsEarned = censusModel.Certs.EarnedPoints,
                PrestigeLevel = censusModel.PrestigeLevel,
                IsOnline = isOnline
            };
        }
    }
}
