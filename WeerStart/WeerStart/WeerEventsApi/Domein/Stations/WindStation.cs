
using WeerEventsApi.Events;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class Windstation : WeerStation
{
    private readonly Random random = new();

    public Windstation(Stad locatie) : base(locatie) { }

    public override Meting DoeMeting()
    {
        double waarde = random.Next(0, 100);
        Meting nieuweMeting = new (waarde, Eenheid.kmh, Locatie);

        //VoegMetingToe(nieuweMeting);
        //return nieuweMeting;

        GedaneMetingen.Add(nieuweMeting); // Voeg toe aan lokale lijst
        MetingEvent.Publiceer(nieuweMeting); // Event publiceren

        return nieuweMeting;
    }
}

