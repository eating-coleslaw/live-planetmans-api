using LivePlanetmans.Data.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Models.QueryResults
{
    public class DeathWithExperience : Death
    {
        public int? ExperienceId { get; set; }
        public int? ExperienceAmount { get; set; }
    }
}
