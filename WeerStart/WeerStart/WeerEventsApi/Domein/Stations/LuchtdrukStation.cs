
using WeerEventsApi.Events;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class LuchtdrukStation : WeerStation
{
    private readonly Random random = new();

    public LuchtdrukStation(Stad locatie) : base(locatie) { }

    public override Meting DoeMeting()
    {
        double waarde = random.Next(900, 1060);
        Meting nieuweMeting = new (waarde, Eenheid.hPa, Locatie);

        //VoegMetingToe(nieuweMeting);
        //return nieuweMeting;

        GedaneMetingen.Add(nieuweMeting); // Voeg toe aan lokale lijst
        MetingEvent.Publiceer(nieuweMeting); // Event publiceren

        return nieuweMeting;
    }
}

 