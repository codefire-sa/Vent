using System.Collections.Generic;

namespace Codefire.Vent
{
    public interface IRequestProvider
    {
        string HostName { get; }
        string Url { get; }
        string HttpMethod { get; }
        string IPAddress { get; }
        IDictionary<string, string> Headers { get; }
        IDictionary<string, string> QueryString { get; set; }
        IDictionary<string, string> Form { get; }
        IDictionary<string, string> Data { get; }
        string Content { get; }
    }
}