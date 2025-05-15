using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein;

public class Meting
{
    public DateTime TijdVanMeting { get; set; }
    public double Waarde { get; set; }
    public Eenheid Eenheid { get; set; }
    public Stad Locatie { get; set; }

    public Meting (double waarde, Eenheid eenheid, Stad locatie)
    {
        TijdVanMeting = DateTime.Now;
        Waarde = waarde;
        Eenheid = eenheid;
        Locatie = locatie;
    }
}

