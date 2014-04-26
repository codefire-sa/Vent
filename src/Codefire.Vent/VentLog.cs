namespace Codefire.Vent
{
    public static class VentLog
    {
        private static IMessageLogger _logger;
        private static readonly EventMessageFactory _events;
        private static readonly MetricMessageFactory _metrics;

        static VentLog()
        {
            _logger = new MessageLogger();
            _events = new EventMessageFactory(_logger);
            _metrics = new MetricMessageFactory(_logger);
        }

        public static IMessageLogger Logger
        {
            get { return _logger; }
        }

        public static void SetLogger(IMessageLogger logger)
        {
            _logger = logger;
        }

        public static EventMessageFactory Events
        { 
            get { return _events; }
        }

        public static MetricMessageFactory Metrics
        {
            get { return _metrics; }
        }
    }
}