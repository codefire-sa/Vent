using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public interface ITarget
    {
        string Name { get; set; }

        void Start();
        void Stop();
        void Process(VentMessage message);
    }
}