using System;
using System.Collections.Generic;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public class MessageLogger : IMessageLogger, IDisposable
    {
        private readonly List<ITarget> _targets;
        private bool _disposed;

        public MessageLogger()
        {
            _targets = new List<ITarget>();
        }

        public string Source { get; set; }

        public ITarget[] Targets
        {
            get { return _targets.ToArray(); }
        }

        public void Publish(VentMessage message)
        {
            _targets.ForEach(item => item.Process(message));
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