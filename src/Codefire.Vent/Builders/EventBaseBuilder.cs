using System;
using System.Collections.Generic;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public abstract class EventBaseBuilder<TBuilder> : MessageBuilder<TBuilder>
        where TBuilder : class, IMessageBuilder
    {
        protected EventBaseBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
            if (logger.Configuration.MachineNameProvider != null)
            {
                MachineName(logger.Configuration.MachineNameProvider());
            }

            if (logger.Configuration.UserNameProvider != null)
            {
                UserName(logger.Configuration.UserNameProvider());
            }

            if (logger.Configuration.VersionProvider != null)
            {
                Version(logger.Configuration.VersionProvider());
            }
        }

        public TBuilder MachineName(string value)
        {
            return Assign(data => data.MachineName = value);
        }

        public TBuilder UserName(string value)
        {
            return Assign(data => data.UserName = value);
        }

        public TBuilder Version(string value)
        {
            return Assign(data => data.Version = value);
        }

        public TBuilder AddData(string name, string value)
        {
            return Assign(data =>
            {
                if (data.Data == null)
                    data.Data = new Dictionary<string, string>();
                
                data.Data.Add(name, value);
            });
        }

        public TBuilder AddTags(params string[] tags)
        {
            return Assign(data =>
            {
                if (data.Tags == null)
                    data.Tags = new List<string>();


                Array.ForEach(tags, item => data.Tags.Add(item));
            });
        }
    }
}