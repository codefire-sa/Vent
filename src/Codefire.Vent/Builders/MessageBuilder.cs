using System;
using System.Threading.Tasks;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public abstract class MessageBuilder<TBuilder> : IMessageBuilder
        where TBuilder : class, IMessageBuilder
    {
        protected MessageBuilder(IVentLog logger, VentMessage msg)
        {
            msg.Source = logger.Configuration.Source;

            Logger = logger;
            InnerMessage = msg;
        }

        public IVentLog Logger { get; private set; }
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

        public TBuilder Assign(Action<dynamic> action)
        {
            action(InnerMessage.MessageData);

            return this as TBuilder;
        }

        public virtual void Publish()
        {
            Logger.Publish(InnerMessage);
        }

        public virtual Task PublishAsync()
        {
            return Logger.PublishAsync(InnerMessage);
        }
    }
}