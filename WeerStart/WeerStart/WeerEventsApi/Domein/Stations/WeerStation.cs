using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public abstract class WeerStation
{
    public Stad Locatie { get; set; }
    public List<Meting> GedaneMetingen = new();

    public WeerStation(Stad locatie)
    {
        Locatie = locatie;
    }
    public List<Meting> GeefGedaneMetingen()
    {
        return GedaneMetingen;
    }
    public abstract Meting GenereerMeting();
    public void VoegMetingToe(Meting meting)
    {
        GedaneMetingen.Add(meting);
    }
}
