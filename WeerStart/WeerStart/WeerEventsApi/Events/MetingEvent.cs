using WeerEventsApi.Domein;

namespace WeerEventsApi.Events
{
    public class MetingEvent
    {
        public static event Action<Meting>? MetingGedaan;

        public static void Publiceer(Meting meting)
        {
            MetingGedaan?.Invoke(meting);
        }
    }
}
