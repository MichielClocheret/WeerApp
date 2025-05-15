using WeerEventsApi.Domein.Managers;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerStation _weerStation;

    public DomeinController(IStadManager stadManager, IWeerStation weerStationManager)
    {
        _stadManager = stadManager;
        _weerStation = weerStationManager;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {  
        //TODO
        return _weerStation.GeefWeerStations().Select(w => new WeerStationDto
        {
            Locatie = w.Locatie,
            GedaneMetingen = w.GedaneMetingen,
        });
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        //TODO
        throw new NotImplementedException();
    }

    public void DoeMetingen()
    {
        //TODO
        throw new NotImplementedException();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        //TODO
        throw new NotImplementedException();
    }
}