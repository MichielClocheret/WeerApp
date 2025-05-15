using WeerEventsApi.Steden;

namespace WeerEventsApi.Domein;

public class WeerBericht
{
    string conclusie;
    public DateTime TijdVanCreatie { get; }
    public string Inhoud { get; }
    public bool IsGoed;

    public WeerBericht()
    {
        TijdVanCreatie = DateTime.Now;
    }

    public WeerBericht(List<Meting> metingen)
    {
        Thread.Sleep(5000);
        //conclusie = metingen.Average(m => m.Waarde) > 15 ? "goed" : "slecht";
        ToString();
    }
    public override string? ToString()
    {
        return $"Op basis van metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {conclusie} weer.";
    }
}

