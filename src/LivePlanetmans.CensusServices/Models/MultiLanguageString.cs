// Credit to Lampjaw

using Newtonsoft.Json;

namespace LivePlanetmans.CensusServices.Models
{
    public class MultiLanguageString
    {
        [JsonProperty("en")]
        public string English { get; set; }
    }
}
