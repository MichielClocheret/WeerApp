
using WeerEventsApi.Events;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class TemperatuurStation : WeerStation
{
    private readonly Random random = new();

    public TemperatuurStation(Stad locatie) : base(locatie) { }

    public override Meting DoeMeting()
    {
        double waarde = random.Next(-5, 30);
        Meting nieuweMeting = new (waarde, Eenheid.C, Locatie);

        //VoegMetingToe(nieuweMeting);
        //return nieuweMeting;

        GedaneMetingen.Add(nieuweMeting); // Voeg toe aan lokale lijst
        MetingEvent.Publiceer(nieuweMeting); // Event publiceren

        return nieuweMeting;
    }
}

