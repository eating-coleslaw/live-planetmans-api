using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace LivePlanetmans.App.CensusStream
{
    public interface IWebsocketEventHandler
    {
        Task Process(JToken jPayload);
    }
}
