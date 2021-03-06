using System;
using System.ComponentModel.DataAnnotations;

namespace LivePlanetmans.Data.Models.Events
{
    public class ContinentUnlock
    {
        [Required]
        public int WorldId { get; set; }
        [Required]
        public int ZoneId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public int? MetagameEventId { get; set; }
        public int? TriggeringFaction { get; set; }
    }
}
