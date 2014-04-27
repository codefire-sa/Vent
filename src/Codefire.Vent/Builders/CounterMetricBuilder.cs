using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class CounterMetricBuilder : MessageBuilder<CounterMetricBuilder>
    {
        public CounterMetricBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
        }

        public CounterMetricBuilder Value(double value)
        {
            return Assign(data => data.Value = value);
        }
    }
}