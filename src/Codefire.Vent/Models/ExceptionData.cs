using System.Collections.Generic;

namespace Codefire.Vent.Models
{
    public class ExceptionData : EventBaseData
    {
        public ExceptionDetailData Exception { get; set; }
    }
}