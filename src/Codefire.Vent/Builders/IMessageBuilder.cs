using System.Threading.Tasks;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public interface IMessageBuilder
    {
        IVentLog Logger { get; }
        VentMessage InnerMessage { get; }

        void Publish();
        Task PublishAsync();
    }
}