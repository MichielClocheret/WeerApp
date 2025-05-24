namespace WeerEventsApi.Domein.Managers
{
    public interface IWeerBericht
    {
        WeerBericht GenereerWeerBericht (List<Meting> metingen);
    }
}
