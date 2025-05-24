using WeerEventsApi.Domein.Managers;
using WeerEventsApi.Domein.Stations;
using WeerEventsApi.Steden.Repositories;

namespace WeerEventsApi.Steden.Managers;

public class WeerStationManager : IWeerStation
{
    private  readonly List<WeerStation> _stations = new();
    public WeerStationManager(IStadRepository stadRepo)
    {
        foreach (var stad in stadRepo.GetSteden())
        {
            _stations.Add(new TemperatuurStation(stad));
            _stations.Add(new Windstation(stad));
            _stations.Add(new NeerslagStation(stad));            
            _stations.Add(new LuchtdrukStation(stad));
        }
    }

    public void DoeMetingen()
    {
        foreach (var station in _stations)
        {
            station.DoeMeting();
        }
    }
    public IEnumerable<WeerStation> GeefWeerStations()
    {
        return _stations;
    }
}