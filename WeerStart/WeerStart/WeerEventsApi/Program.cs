using WeerEventsApi.Domein.Managers;
using WeerEventsApi.Events;
using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true,true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();
builder.Services.AddSingleton<IWeerStation, WeerStationManager>();
builder.Services.AddSingleton<IWeerBericht, WeerberichtManager>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
//TODO api aanvullen

app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());

app.MapPost("/commands/meting-command", (IDomeinController dc) =>
{
    dc.DoeMetingen();
    if(dc.GeefMetingen().Count() == 12)
    {
        return Results.Ok("Alle metingen zijn uitgevoerd");
    }
    else
    {
        return Results.BadRequest("Niet alle metingen zijn uitgevoerd");
    }
});
    

app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());

app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());


var logger = app.Services.GetRequiredService<IMetingLogger>();
MetingEvent.MetingGedaan += meting =>
{
    var message = $"Meting in {meting.Locatie.Naam}: {meting.Waarde} {meting.Eenheid}";
    logger.Log(message);
};

app.Run();