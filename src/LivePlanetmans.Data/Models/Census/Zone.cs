using System.ComponentModel.DataAnnotations;

namespace LivePlanetmans.Data.Models.Census
{
    public class Zone
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int? HexSize { get; set; }
    }
}
