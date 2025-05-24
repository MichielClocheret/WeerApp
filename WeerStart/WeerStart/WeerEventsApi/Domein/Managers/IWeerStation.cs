using WeerEventsApi.Domein.Stations;

namespace WeerEventsApi.Domein.Managers;

public interface IWeerStation
{
    IEnumerable<WeerStation> GeefWeerStations();
    void DoeMetingen();
}