using System.Collections.Concurrent;

namespace WeerEventsApi.Domein.Managers
{
    public class WeerberichtManager : IWeerBericht
    {
        private readonly ConcurrentDictionary<string, (DateTime tijdstip, WeerBericht bericht)> _cache = new();
        private readonly TimeSpan _cacheDuur = TimeSpan.FromMinutes(10);

        public WeerBericht GenereerWeerBericht(List<Meting> metingen)
        {
            string sleutel = GenereerSleutel(metingen);

            if (_cache.TryGetValue(sleutel, out var cached))
            {
                if ((DateTime.Now - cached.tijdstip) < _cacheDuur)
                    return cached.bericht;
            }

            var nieuwBericht = new WeerBericht(metingen);
            _cache[sleutel] = (DateTime.Now, nieuwBericht);
            return nieuwBericht;
        }

        private string GenereerSleutel(List<Meting> metingen)
        {
            return string.Join("-", metingen
                .Where(m => m.Locatie != null)
                .Select(m => m.Locatie.Naam)
                .Distinct()
                .OrderBy(n => n));
        }
    }
}
