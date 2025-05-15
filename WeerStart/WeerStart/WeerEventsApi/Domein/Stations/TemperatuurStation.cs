
using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein.Stations;

public class TemperatuurStation : WeerStation
{
    private readonly Random random = new();

    public TemperatuurStation(Stad locatie) : base(locatie)
    {
                
    }

    public override Meting GenereerMeting()
    {
        double waarde = random.Next(-5, 30);
        Meting nieuweMeting = new (waarde, Eenheid.GradenCelsius, Locatie);

        VoegMetingToe(nieuweMeting);
        return nieuweMeting;
    }
}

