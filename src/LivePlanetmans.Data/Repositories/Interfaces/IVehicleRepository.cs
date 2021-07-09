using LivePlanetmans.Data.Models.Census;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
        Task UpsertRangeAsync(IEnumerable<Vehicle> entities);
        Task UpsertRangeAsync(IEnumerable<VehicleFaction> entities);
    }
}
