using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class EventBuilder : EventBaseBuilder<EventBuilder>
    {
        public EventBuilder(IMessageLogger logger, VentMessage msg)
            : base(logger, msg)
        {
        }
    }
}