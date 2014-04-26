using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public interface IMessageBuilder
    {
        IMessageLogger Logger { get; }
        VentMessage InnerMessage { get; }

        void Publish();
    }
}