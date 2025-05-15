using WeerEventsApi.Domein;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Facade.Dto;

public class WeerStationDto
{
    //TODO
    public required Stad Locatie { get; set; }
    public required List<Meting> GedaneMetingen = new();
}