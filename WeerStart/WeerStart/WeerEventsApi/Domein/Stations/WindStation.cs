
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class Windstation : WeerStation
{
    private readonly Random random = new();

    public Windstation(Stad locatie) : base(locatie)
    {
                
    }

    public override Meting GenereerMeting()
    {
        double waarde = random.Next(0, 100);
        Meting nieuweMeting = new (waarde, Eenheid.KilometerPerUur, Locatie);

        VoegMetingToe(nieuweMeting);
        return nieuweMeting;
    }
}

