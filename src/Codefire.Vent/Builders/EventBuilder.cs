using System;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class EventBuilder : EventBaseBuilder<EventBuilder>
    {
        public EventBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public EventBuilder Level(string value)
        {
            return Assign(data => data.Level = value);
        }

        public EventBuilder Message(string value)
        {
            return Assign(data => data.Message = value);
        }

        public EventBuilder MessageFormat(string format, params object[] args)
        {
            var value = string.Format(format, args);

            return Assign(data => data.Message = value);
        }

        public EventBuilder MessageFormat(IFormatProvider provider, string format, params object[] args)
        {
            var value = string.Format(provider, format, args);

            return Assign(data => data.Message = value);
        }
    }
}