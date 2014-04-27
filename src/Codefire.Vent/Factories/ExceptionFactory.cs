using System;
using Codefire.Vent.Builders;
using Codefire.Vent.Models;

namespace Codefire.Vent.Factories
{
    public class ExceptionMessageFactory
    {
        private readonly IVentLog _logger;

        public ExceptionMessageFactory(IVentLog logger)
        {
            _logger = logger;
        }

        public ExceptionBuilder CreateException(Exception ex)
        {
            var exceptionType = ex.GetType();

            var exceptionMsg = new VentMessage
            {
                Name = exceptionType.Name,
                MessageType = MessageType.Exception,
                Timestamp = DateTime.Now
            };

            var builder = new ExceptionBuilder(_logger, exceptionMsg);
            builder.Exception(ex);

            return builder;
        }
    }
}
