using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class ExceptionBuilder : EventBaseBuilder<ExceptionBuilder>
    {
        public ExceptionBuilder(IMessageLogger logger, VentMessage msg)
            : base(logger, msg)
        {
        }
    }
}