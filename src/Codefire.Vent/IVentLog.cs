using System.Threading.Tasks;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public interface IVentLog
    {
        IVentConfiguration Configuration { get; set; }
        ITarget[] Targets { get; }

        void AddTarget(ITarget target);
        void RemoveTarget(string name);
        void RemoveAllTargets();
        void Publish(VentMessage message);
        Task PublishAsync(VentMessage message);
    }
}