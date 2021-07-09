using static LivePlanetmans.CensusServices.Models.CensusCharacterModel;

namespace LivePlanetmans.CensusServices.Models
{
    public class CensusOutfitMemberCharacterModel : CensusOutfitMemberModel
    {
        public CharacterName Name { get; set; }

        public string OnlineStatus { get; set; }
        public int PrestigeLevel { get; set; }

        public string OutfitAlias { get; set; }
        public string OutfitAliasLower { get; set; }
    }
}
