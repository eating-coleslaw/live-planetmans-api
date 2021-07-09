using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace LivePlanetmans.App.Services.Planetside
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicleInfo(int vehicleId);
    }
}
