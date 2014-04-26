using System.Collections.Generic;

namespace Codefire.Vent.Models
{
    public class ExceptionDetailData
    {
        public ExceptionDetailData()
        {
            StackTrace = new List<StackTraceData>();
        }

        public string ClassName { get; set; }
        public string Message { get; set; }
        public List<StackTraceData> StackTrace { get; set; }
        public ExceptionDetailData InnerException { get; set; }
    }
}