namespace Codefire.Vent.Models
{
    public static class MessageType
    {
        public const string Event = "event";
        public const string Exception = "exception";
        public const string Counter = "metric/counter";
        public const string Gauge = "metric/gauge";
        public const string Timer = "metric/timer";
    }
}