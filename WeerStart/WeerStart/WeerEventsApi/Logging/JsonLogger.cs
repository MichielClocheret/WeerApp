namespace WeerEventsApi.Logging
{
    public class JsonLogger : IMetingLogger
    {
        private readonly IMetingLogger _baseLogger;
        public JsonLogger(IMetingLogger baseLogger)
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
