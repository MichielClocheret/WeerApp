using WeerEventsApi.Domein;
using WeerEventsApi.Domein.Managers;
using WeerEventsApi.Domein.Stations;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerStation _weerStation;
    private readonly IWeerBericht _weerBericht;

    public DomeinController(IStadManager stadManager, IWeerStation weerStationManager, IWeerBericht weerbericht)
    {
        _stadManager = stadManager;
        _weerStation = weerStationManager;
        _weerBericht = weerbericht;
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
        return _weerStation.GeefWeerStations().Select(weerstation => new WeerStationDto
        { 
            Locatie = weerstation.Locatie,
            GedaneMetingen = weerstation.GedaneMetingen
        });
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        //TODO
        return _weerStation.GeefWeerStations().SelectMany(weerstation => weerstation.GedaneMetingen)
            .Select(m => new MetingDto
            {
                TijdVanMeting = m.TijdVanMeting,
                Waarde = m.Waarde,
                Eenheid = m.Eenheid,
                Locatie = m.Locatie
            });
    }

    public void DoeMetingen()
    {
        //TODO
        _weerStation.DoeMetingen();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        //TODO
        var metingen = _weerStation.GeefWeerStations()
            .SelectMany(ws => ws.GeefGedaneMetingen()).ToList();

        var weerBericht = _weerBericht.GenereerWeerBericht(metingen);

        return new WeerBerichtDto
        {
            TijdVanCreatie = weerBericht.TijdVanCreatie,
            Inhoud = weerBericht.Inhoud
        };
    }
}