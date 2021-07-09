using System.Collections.Generic;

namespace LivePlanetmans.CensusServices.Models
{
    public class CensusOutfitMemberCharactersModel : CensusOutfitModel
    {
        public IEnumerable<CensusOutfitMemberCharacterModel> Members { get; set; }
    }
}
