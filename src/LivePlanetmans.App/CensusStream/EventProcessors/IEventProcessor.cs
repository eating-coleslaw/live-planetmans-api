// Credit to Lampjaw

using System.Threading.Tasks;

namespace LivePlanetmans.App.CensusStream.EventProcessors
{
    public interface IEventProcessor<TPayload> where TPayload : class
    {
        Task Process(TPayload payload);
    }
}
