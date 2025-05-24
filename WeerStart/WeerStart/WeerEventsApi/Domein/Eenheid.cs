using System.Text.Json.Serialization;

namespace WeerEventsApi.Domein;

[JsonConverter(typeof(JsonStringEnumConverter))] //Zorgt ervoor dat de eenheid in string wordt gebruikt ipv de indexes
public enum Eenheid
{
    kmh,
    ms,
    C,
    hPa
}