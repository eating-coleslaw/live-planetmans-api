using LivePlanetmans.Data.Models.Census;
using System;
using System.ComponentModel.DataAnnotations;

namespace LivePlanetmans.Data.Models.Events
{
    public class PlayerLogout
    {
        [Required]
        public string CharacterId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public int WorldId { get; set; }

        #region Navigation Properties
        public Character Character { get; set; }
        #endregion Navigation Properties
    }
}
