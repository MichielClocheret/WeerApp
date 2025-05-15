using WeerEventsApi.Domein;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{
    //TODO
    public required DateTime TijdVanMeting { get; set; }
    public required double Waarde { get; set; }
    public required Eenheid Eenheid { get; set; }
    public required Stad Locatie { get; set; }
}