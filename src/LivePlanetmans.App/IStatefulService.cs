using LivePlanetmans.App.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LivePlanetmans.App
{
    public interface IStatefulService
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
        Task<ServiceState> GetStateAsync(CancellationToken cancellationToken);
        string ServiceName { get; }
    }
}
