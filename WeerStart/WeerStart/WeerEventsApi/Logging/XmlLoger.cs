namespace WeerEventsApi.Logging
{
    public class XmlLoger : IMetingLogger
    {
        private readonly IMetingLogger _baseLogger;
        public XmlLoger(IMetingLogger baseLogger)
        {
            _baseLogger = baseLogger;
        }
        public void Log(string message)
        {
            string jsonMessage = message;
            _baseLogger.Log(jsonMessage);
        }
    }
}
