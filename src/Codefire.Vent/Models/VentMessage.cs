using System;
using System.Dynamic;

namespace Codefire.Vent.Models
{
    public class VentMessage
    {
        public VentMessage()
        {
            Timestamp = DateTime.Now;
            MessageData = new ExpandoObject();
        }

        public string Source { get; set; }
        public string Name { get; set; }
        public string MessageType { get; set; }
        public DateTime Timestamp { get; set; }
        public dynamic MessageData { get; set; }
    }
}