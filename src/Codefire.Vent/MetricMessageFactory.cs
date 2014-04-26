using System;
using System.Diagnostics;
using Codefire.Vent.Builders;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public class MetricMessageFactory
    {
        private readonly IMessageLogger _logger;

        public MetricMessageFactory(IMessageLogger logger)
        {
            _logger = logger;
        }

        public CounterMetricBuilder Counter(string name)
        {
            var metricMsg = CreateMessage(name, MessageType.Counter);

            return new CounterMetricBuilder(_logger, metricMsg);
        }

        public GaugeMetricBuilder Gauge(string name)
        {
            var metricMsg = CreateMessage(name, MessageType.Gauge);

            return new GaugeMetricBuilder(_logger, metricMsg);
        }

        public TimerMetricBuilder Timer(string name)
        {
            var metricMsg = CreateMessage(name, MessageType.Timer);

            return new TimerMetricBuilder(_logger, metricMsg);
        }

        protected VentMessage CreateMessage(string name, string type)
        {
            var metricMsg = new VentMessage
            {
                Source = _logger.Source,
                Name = name,
                MessageType = type,
                MessageData = new MetricData(),
                Timestamp = DateTime.Now
            };

            return metricMsg;
        }
    }
}
