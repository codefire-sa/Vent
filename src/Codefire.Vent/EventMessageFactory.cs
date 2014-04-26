using System;
using Codefire.Vent.Builders;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public class EventMessageFactory
    {
        private readonly IMessageLogger _logger;

        public EventMessageFactory(IMessageLogger logger)
        {
            _logger = logger;
        }

        #region [ Debug ]

        public EventBuilder Debug(string message)
        {
            return CreateEvent(LogLevel.Debug, message);
        }

        public EventBuilder DebugFormat(string format, params object[] args)
        {
            return CreateEvent(LogLevel.Debug, string.Format(format, args));
        }

        public EventBuilder DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            return CreateEvent(LogLevel.Debug, string.Format(provider, format, args));
        }

        public ExceptionBuilder Debug(Exception ex)
        {
            return CreateException(LogLevel.Debug, ex);
        }

        #endregion

        #region [ Info ]

        public EventBuilder Info(string message)
        {
            return CreateEvent(LogLevel.Information, message);
        }

        public EventBuilder InfoFormat(string format, params object[] args)
        {
            return CreateEvent(LogLevel.Information, string.Format(format, args));
        }

        public EventBuilder InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            return CreateEvent(LogLevel.Information, string.Format(provider, format, args));
        }

        public ExceptionBuilder Info(Exception ex)
        {
            return CreateException(LogLevel.Information, ex);
        }

        #endregion

        #region [ Warn ]

        public EventBuilder Warn(string message)
        {
            return CreateEvent(LogLevel.Warning, message);
        }

        public EventBuilder WarnFormat(string format, params object[] args)
        {
            return CreateEvent(LogLevel.Warning, string.Format(format, args));
        }

        public EventBuilder WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            return CreateEvent(LogLevel.Warning, string.Format(provider, format, args));
        }

        public ExceptionBuilder Warn(Exception ex)
        {
            return CreateException(LogLevel.Warning, ex);
        }

        #endregion

        #region [ Error ]

        public EventBuilder Error(string message)
        {
            return CreateEvent(LogLevel.Error, message);
        }

        public EventBuilder ErrorFormat(string format, params object[] args)
        {
            return CreateEvent(LogLevel.Error, string.Format(format, args));
        }

        public EventBuilder ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            return CreateEvent(LogLevel.Error, string.Format(provider, format, args));
        }

        public ExceptionBuilder Error(Exception ex)
        {
            return CreateException(LogLevel.Error, ex);
        }

        #endregion

        #region [ Fatal ]

        public EventBuilder Fatal(string message)
        {
            return CreateEvent(LogLevel.Fatal, message);
        }

        public EventBuilder FatalFormat(string format, params object[] args)
        {
            return CreateEvent(LogLevel.Fatal, string.Format(format, args));
        }

        public EventBuilder FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            return CreateEvent(LogLevel.Fatal, string.Format(provider, format, args));
        }

        public ExceptionBuilder Fatal(Exception ex)
        {
            return CreateException(LogLevel.Fatal, ex);
        }

        #endregion

        protected EventBuilder CreateEvent(string level, string message)
        {
            var eventMsg = new VentMessage
                {
                    Source = _logger.Source,
                    MessageType = MessageType.Event,
                    MessageData = new EventData { Level = level, Message = message },
                    Timestamp = DateTime.Now
                };

            return new EventBuilder(_logger, eventMsg);
        }

        protected ExceptionBuilder CreateException(string level, Exception ex)
        {
            var exceptionType = ex.GetType();

            var exceptionMsg = new VentMessage
                {
                    Source = _logger.Source,
                    Name = exceptionType.Name,
                    MessageType = MessageType.Exception,
                    Timestamp = DateTime.Now
                };

            var data = new ExceptionData();
            data.Level = level;
            data.Message = exceptionType.Name + ": " + ex.Message;
            data.Exception = CreateExceptionDetail(ex);

            exceptionMsg.MessageData = data;

            return new ExceptionBuilder(_logger, exceptionMsg);
        }

        private ExceptionDetailData CreateExceptionDetail(Exception ex)
        {
            var exceptionType = ex.GetType();

            var data = new ExceptionDetailData();
            data.Message = ex.Message;
            data.ClassName = exceptionType.FullName;
            data.StackTrace.AddRange(ex.BuildStackTrace());

            if (ex.InnerException != null)
                data.InnerException = CreateExceptionDetail(ex.InnerException);

            return data;
        }
    }
}