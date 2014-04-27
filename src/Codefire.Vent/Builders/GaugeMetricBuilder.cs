using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class GaugeMetricBuilder : MessageBuilder<GaugeMetricBuilder>
    {
        public GaugeMetricBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public GaugeMetricBuilder Value(double value)
        {
            return Assign(data => data.Value = value);
        }
    }
}