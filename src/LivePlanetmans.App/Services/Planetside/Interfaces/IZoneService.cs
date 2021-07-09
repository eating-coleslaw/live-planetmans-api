using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface IZoneService
    {
        Task<IEnumerable<Zone>> GetAllZones();
        Task<Zone> GetZone(int zoneId);
    }
}
