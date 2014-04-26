using Codefire.Vent.Models;

namespace Codefire.Vent.Targets
{
    public abstract class Target : ITarget
    {
        protected Target(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
        }

        public abstract void Process(VentMessage message);
    }
}