﻿using LivePlanetmans.CensusStore.Services;
using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterStore _characterStore;
        
        private readonly IOutfitService _outfitService;

        public CharacterService(ICharacterStore characterStore, IOutfitService outfitService)
        {
            _characterStore = characterStore;
            _outfitService = outfitService;
        }

        public async Task<Character> GetCharacter(string characterId)
        {
            return await _characterStore.GetCharacterAsync(characterId);
        }

        public async Task<Character> GetCharacterByName(string characterName)
        {
            return await _characterStore.GetCharacterByNameAsync(characterName);
        }

        public async Task<OutfitMember> GetCharacterOutfit(string characterId)
        {
            var character = await GetCharacter(characterId);

            if (character == null)
            {
                return null;
            }

            return await _outfitService.GetUpdatedCharacterOutfitMembership(character);
        }
    }
}
