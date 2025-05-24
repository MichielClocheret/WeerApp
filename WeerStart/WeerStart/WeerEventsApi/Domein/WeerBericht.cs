using WeerEventsApi.Domein.Stations;

namespace WeerEventsApi.Domein;

public class WeerBericht
{
    public DateTime TijdVanCreatie { get; }
    public string Inhoud { get; }
     
    public WeerBericht(List<Meting> metingen)
    {
        TijdVanCreatie = DateTime.Now;

        if (metingen == null || metingen.Count == 0)
        {
            Inhoud = "Geen metingen beschikbaar.";
            return;
        }

        Thread.Sleep(5000);
        double gemiddelde = metingen.Average(m => m.Waarde);

        string conclusie = "onbekend";
        foreach (var m in metingen)
        {
            switch (m.Eenheid)
            {
                case Eenheid.kmh:
                    if (m.Waarde < 30)
                    {
                        conclusie = "goed";
                    }
                    break;
                case Eenheid.ms:
                    if (m.Waarde > 50)
                    {
                        conclusie = "goed";
                    }
                    break;
                case Eenheid.C:
                    if (m.Waarde > 20)
                    {
                        conclusie = "slecht";
                    }
                    break;
                case Eenheid.hPa:
                    if (m.Waarde < 1000)
                    {
                        conclusie = "slecht";
                    }
                    break;
                default:
                    conclusie = "onbekend";
                    break;
            }
        }

        Inhoud = $"Op basis van {metingen.Count} metingenen mijn diepzinnig computermodel kan ik zeggen dat er kans is op {conclusie} weer.";
    }
}

 