using LivePlanetmans.Data.Models.Census;
using System.Threading.Tasks;

namespace CensusStore.Services
{
    public interface IMetagameEventStore : IUpdateable
    {
        Task<MetagameEventCategory> GetMetagameEventCategoryAsync(int metagameEventId);
    }
}
