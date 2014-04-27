using System;
using Codefire.Vent.Builders;
using Codefire.Vent.Models;

namespace Codefire.Vent.Factories
{
    public class EventMessageFactory
    {
        private readonly IVentLog _logger;

        public EventMessageFactory(IVentLog logger)
        {
            _logger = logger;
        }

        public EventBuilder Debug(string name)
        {
            return CreateEvent(LogLevel.Debug, name);
        }

        public EventBuilder Info(string name)
        {
            return CreateEvent(LogLevel.Information, name);
        }

        public EventBuilder Warn(string name)
        {
            return CreateEvent(LogLevel.Warning, name);
        }

        public EventBuilder Error(string name)
        {
            return CreateEvent(LogLevel.Error, name);
        }

        public EventBuilder Fatal(string name)
        {
            return CreateEvent(LogLevel.Fatal, name);
        }

        protected EventBuilder CreateEvent(string level, string name)
        {
            var eventMsg = new VentMessage
                {
                    Name = name,
                    MessageType = MessageType.Event,
                    Timestamp = DateTime.Now
                };

            var builder = new EventBuilder(_logger, eventMsg);
            builder.Level(level);

            return builder;
        }
    }
}