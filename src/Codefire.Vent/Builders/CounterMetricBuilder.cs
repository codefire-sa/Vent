using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class CounterMetricBuilder : MessageBuilder<CounterMetricBuilder>
    {
        public CounterMetricBuilder(IMessageLogger logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public CounterMetricBuilder Value(double value)
        {
            return Assign<MetricData>(data => data.Value = value);
        }
    }
}