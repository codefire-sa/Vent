using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class GaugeMetricBuilder : MessageBuilder<GaugeMetricBuilder>
    {
        public GaugeMetricBuilder(IMessageLogger logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public GaugeMetricBuilder Value(double value)
        {
            return Assign<MetricData>(data => data.Value = value);
        }
    }
}