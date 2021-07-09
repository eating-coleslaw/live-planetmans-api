using System.ComponentModel.DataAnnotations;

namespace LivePlanetmans.Data.Models.Census
{
    public class FacilityType
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
