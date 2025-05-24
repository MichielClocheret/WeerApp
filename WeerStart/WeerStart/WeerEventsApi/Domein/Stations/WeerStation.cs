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
    public abstract Meting DoeMeting();

    //public void VoegMetingToe(Meting meting)
    //{
    //    GedaneMetingen.Add(meting);
    //}

    public List<Meting> GeefGedaneMetingen()
    {
        return GedaneMetingen;
    }
}
