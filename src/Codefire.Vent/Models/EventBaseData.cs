using System.Collections.Generic;

namespace Codefire.Vent.Models
{
    public abstract class EventBaseData
    {
        protected EventBaseData()
        {
            Tags = new List<string>();
            Data = new Dictionary<string, object>();
        }

        public string Level { get; set; }
        public string Message { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Version { get; set; }
        public IDictionary<string, object> Data { get; set; }
        public IList<string> Tags { get; set; }
    }
}