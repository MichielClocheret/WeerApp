
using WeerEventsApi.Events;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class NeerslagStation : WeerStation
{
    private readonly Random random = new();

    public NeerslagStation(Stad locatie) : base(locatie) { }

    public override Meting DoeMeting()
    {
        double waarde = random.Next(50, 100);
        Meting nieuweMeting = new(waarde, Eenheid.ms, Locatie);

        //VoegMetingToe(nieuweMeting);
        //return nieuweMeting;
         
        GedaneMetingen.Add(nieuweMeting); // Voeg toe aan lokale lijst
        MetingEvent.Publiceer(nieuweMeting); // Event publiceren

        return nieuweMeting;
    }
}

