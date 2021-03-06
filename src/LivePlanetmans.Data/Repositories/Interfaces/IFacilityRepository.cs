using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<MapRegion>> GetAllMapRegionsAsync();
        Task<IEnumerable<MapRegion>> GetMapRegionsByZoneIdAsync(int zoneId);
        Task<IEnumerable<MapRegion>> GetMapRegionsByFacilityTypeAsync(int facilityTypeId);
        Task<IEnumerable<MapRegion>> GetMapRegionsByFacilityIdsAsync(IEnumerable<int> facilityIds);
        
        Task<IEnumerable<FacilityLink>> GetFacilityLinksByZoneIdAsync(int zoneId);
        Task<IEnumerable<FacilityLink>> GetFacilityLinksByFacilityIdsAsync(IEnumerable<int> facilityIds);
        
        Task UpsertRangeAsync(IEnumerable<MapRegion> censusEntities);
        Task UpsertRangeAsync(IEnumerable<FacilityLink> entities);
        Task UpserRangeAsync(IEnumerable<FacilityType> entities);
    }
}
