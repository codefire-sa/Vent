using System;
using Codefire.Vent.Builders;
using Codefire.Vent.Factories;

namespace Codefire.Vent
{
    public static class VentLogExtensions
    {
        public static EventMessageFactory Events(this IVentLog logger)
        {
            return new EventMessageFactory(logger);
        }

        public static ExceptionBuilder Exception(this IVentLog logger, Exception ex)
        {
            var factory = new ExceptionMessageFactory(logger);

            return factory.CreateException(ex);
        }

        public static MetricMessageFactory Metrics(this IVentLog logger)
        {
            return new MetricMessageFactory(logger);
        }
    }
}