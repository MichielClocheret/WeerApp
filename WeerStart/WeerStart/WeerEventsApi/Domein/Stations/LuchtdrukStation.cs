
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class LuchtdrukStation : WeerStation
{
    private readonly Random random = new();

    public LuchtdrukStation(Stad locatie) : base(locatie)
    {
                
    }

    public override Meting GenereerMeting()
    {
        double waarde = random.Next(900, 1060);
        Meting nieuweMeting = new (waarde, Eenheid.Hectopascal, Locatie);

        VoegMetingToe(nieuweMeting);
        return nieuweMeting;
    }
}

