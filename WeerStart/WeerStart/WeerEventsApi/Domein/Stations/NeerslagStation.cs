
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class NeerslagStation : WeerStation
{
    private readonly Random random = new();

    public NeerslagStation(Stad locatie) : base(locatie)
    {
                
    }

    public override Meting GenereerMeting()
    {
        double waarde = random.Next(50, 100);
        Meting nieuweMeting = new (waarde, Eenheid.MilimeterPerVierkanteMeterPerUur, Locatie);

        VoegMetingToe(nieuweMeting);
        return nieuweMeting;
    }
}

