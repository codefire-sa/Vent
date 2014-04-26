using System;

namespace Codefire.Vent.Models
{
    public class VentMessage
    {
        public VentMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string Source { get; set; }
        public string Name { get; set; }
        public string MessageType { get; set; }
        public DateTime Timestamp { get; set; }
        public object MessageData { get; set; }
    }
}