using System;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public abstract class MessageBuilder<TBuilder> : IMessageBuilder
        where TBuilder : class, IMessageBuilder
    {
        protected MessageBuilder(IMessageLogger logger, VentMessage msg)
        {
            Logger = logger;
            InnerMessage = msg;
        }

        public IMessageLogger Logger { get; private set; }
        public VentMessage InnerMessage { get; private set; }

        public TBuilder Source(string value)
        {
            InnerMessage.Source = value;

            return this as TBuilder;
        }

        public TBuilder Name(string value)
        {
            InnerMessage.Name = value;

            return this as TBuilder;
        }

        public TBuilder Timestamp(DateTime value)
        {
            InnerMessage.Timestamp = value;

            return this as TBuilder;
        }

        protected TBuilder Assign<TData>(Action<TData> action)
        {
            var data = (TData)InnerMessage.MessageData;

            action(data);

            return this as TBuilder;
        }

        public virtual void Publish()
        {
            Logger.Publish(InnerMessage);
        }
    }
}