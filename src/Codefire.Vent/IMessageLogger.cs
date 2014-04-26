using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public interface IMessageLogger
    {
        string Source { get; set; }
        ITarget[] Targets { get; }

        void AddTarget(ITarget target);
        void RemoveTarget(string name);
        void RemoveAllTargets();
        void Publish(VentMessage message);
    }
}