using static LivePlanetmans.App.CensusStream.WebsocketMonitorHelper;

namespace LivePlanetmans.App.CensusStream
{
    public interface IWebsocketMonitorHelper
    {
        WebsocketMonitorFactory GetFactory();
    }
}
