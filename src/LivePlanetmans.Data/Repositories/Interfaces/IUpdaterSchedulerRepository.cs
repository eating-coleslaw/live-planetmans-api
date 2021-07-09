using LivePlanetmans.Data.Models;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface IUpdaterSchedulerRepository
    {
        UpdaterScheduler GetUpdaterHistoryByServiceName(string serviceName);
        Task UpsertAsync(UpdaterScheduler entity);
    }
}
