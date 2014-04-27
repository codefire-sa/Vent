using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public class VentLog : IVentLog, IDisposable
    {
        private readonly List<ITarget> _targets;
        private bool _disposed;

        public VentLog()
        {
            Configuration = new VentConfiguration();
            _targets = new List<ITarget>();
        }

        public IVentConfiguration Configuration { get; set; }

        public ITarget[] Targets
        {
            get { return _targets.ToArray(); }
        }

        public void AddTarget(ITarget target)
        {
            target.Start();

            _targets.Add(target);
        }

        public void RemoveTarget(string name)
        {
            _targets.RemoveAll(item =>
            {
                if (item.Name != name) return false;

                item.Stop();
                return true;
            });
        }

        public void RemoveAllTargets()
        {
            _targets.RemoveAll(item =>
            {
                item.Stop();
                return true;
            });
        }

        public void Publish(VentMessage message)
        {
            _targets.ForEach(item => item.Process(message));
        }

        public async Task PublishAsync(VentMessage message)
        {
            foreach (var item in _targets)
            {
                await item.ProcessAsync(message);
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    RemoveAllTargets();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}