using WeerEventsApi.Domein.Managers;
using WeerEventsApi.Domein.Stations;

namespace WeerEventsApi.Steden.Managers;

public class WeerStationManager(IWeerStation _weerStation)
{
    public IEnumerable<WeerStation> GeefWeerStations()
    {
        return _weerStation.GeefWeerStations();
    }
}