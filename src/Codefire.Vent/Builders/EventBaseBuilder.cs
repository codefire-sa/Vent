using System;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public abstract class EventBaseBuilder<TBuilder> : MessageBuilder<TBuilder>
        where TBuilder : class, IMessageBuilder
    {
        protected EventBaseBuilder(IMessageLogger logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public TBuilder Level(string value)
        {
            return Assign<EventData>(data => data.Level = value);
        }

        public TBuilder Message(string value)
        {
            return Assign<EventData>(data => data.Message = value);
        }

        public TBuilder MessageFormat(string format, params object[] args)
        {
            var value = string.Format(format, args);

            return Assign<EventData>(data => data.Message = value);
        }

        public TBuilder MessageFormat(IFormatProvider provider, string format, params object[] args)
        {
            var value = string.Format(provider, format, args);

            return Assign<EventData>(data => data.Message = value);
        }

        public TBuilder Host(string value)
        {
            return Assign<EventBaseData>(data => data.HostName = value);
        }

        public TBuilder User(string value)
        {
            return Assign<EventBaseData>(data => data.UserName = value);
        }

        public TBuilder Version(string value)
        {
            return Assign<EventBaseData>(data => data.Version = value);
        }

        public TBuilder AddData(string name, object value)
        {
            return Assign<EventBaseData>(data => data.Data.Add(name, value));
        }

        public TBuilder AddTags(params string[] tags)
        {
            return Assign<EventBaseData>(data => Array.ForEach(tags, item => data.Tags.Add(item)));
        }
    }
}