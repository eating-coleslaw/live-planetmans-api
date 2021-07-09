using System;

namespace LivePlanetmans.App.CensusStream.Models
{
    public class CensusHeartbeat
    {
        public DateTime LastHeartbeat { get; set; }
        public object Contents { get; set; }
    }
}
