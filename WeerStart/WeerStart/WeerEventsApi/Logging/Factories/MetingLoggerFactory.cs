namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        //TODO Alle combinaties moeten mogelijk zijn (false,false | true,false | false,true | true,true)
        IMetingLogger baseLogger = new MetingLogger();
        if (decorateWithJson && decorateWithXml)
        {
            return new JsonLogger(new XmlLoger(baseLogger));
        }
        if (decorateWithJson)
        {
            return new JsonLogger(baseLogger);

        }
        if (decorateWithXml)
        {
            return new XmlLoger(baseLogger);

        }
        return baseLogger;
    }
}