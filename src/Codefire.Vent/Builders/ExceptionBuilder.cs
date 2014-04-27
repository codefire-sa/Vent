using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Text;
using Codefire.Vent.Models;

namespace Codefire.Vent.Builders
{
    public class ExceptionBuilder : EventBaseBuilder<ExceptionBuilder>
    {
        public ExceptionBuilder(IVentLog logger, VentMessage msg)
            : base(logger, msg)
        {
            if (logger.Configuration.EnvironmentProvider != null)
            {
                Assign(data => data.Environment = logger.Configuration.EnvironmentProvider());
            }
        }

        public ExceptionBuilder Exception(Exception ex)
        {
            return Assign(data => data.Exception = CreateExceptionDetail(ex));
        }

        public ExceptionBuilder Request(IRequestProvider request)
        {
            return Assign(data => data.Request = CreateRequest(request));
        }

        private dynamic CreateExceptionDetail(Exception ex)
        {
            var exType = ex.GetType();

            dynamic data = new ExpandoObject();
            data.Message = string.Format("{0}: {1}", exType.Name, ex.Message);
            data.ClassName = exType.FullName;
            data.StackTrace = new List<dynamic>();
            data.StackTrace.AddRange(BuildStackTrace(ex));

            if (ex.InnerException != null)
                data.InnerException = CreateExceptionDetail(ex.InnerException);

            return data;
        }

        private IEnumerable<dynamic> BuildStackTrace(Exception ex)
        {
            var stackTrace = new StackTrace(ex, true);
            var frames = stackTrace.GetFrames();

            if (frames == null || frames.Length == 0)
            {
                yield break;
            }

            foreach (StackFrame frame in frames)
            {
                MethodBase method = frame.GetMethod();

                if (method != null)
                {
                    string file = frame.GetFileName();
                    int lineNumber = frame.GetFileLineNumber();

                    if (lineNumber == 0)
                    {
                        lineNumber = frame.GetILOffset();
                    }

                    var methodName = GenerateMethodName(method);
                    var className = method.ReflectedType.FullName;

                    dynamic line = new ExpandoObject();
                    line.FileName = file;
                    line.LineNumber = lineNumber;
                    line.MethodName = methodName;
                    line.ClassName = className;

                    yield return line;
                }
            }
        }

        private string GenerateMethodName(MethodBase method)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(method.Name);

            if (method is MethodInfo && method.IsGenericMethod)
            {
                Type[] genericArguments = method.GetGenericArguments();
                stringBuilder.Append("[");
                int index2 = 0;
                bool flag2 = true;
                for (; index2 < genericArguments.Length; ++index2)
                {
                    if (!flag2)
                        stringBuilder.Append(",");
                    else
                        flag2 = false;
                    stringBuilder.Append(genericArguments[index2].Name);
                }
                stringBuilder.Append("]");
            }
            stringBuilder.Append("(");
            ParameterInfo[] parameters = method.GetParameters();
            bool flag3 = true;
            for (int index2 = 0; index2 < parameters.Length; ++index2)
            {
                if (!flag3)
                    stringBuilder.Append(", ");
                else
                    flag3 = false;
                //string str2 = "<UnknownType>";
                //if (parameters[index2].ParameterType != null)
                //    str2 = parameters[index2].ParameterType.Name;
                //stringBuilder.Append(str2 + " " + parameters[index2].Name);
                stringBuilder.Append(parameters[index2].Name);
            }
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private dynamic CreateRequest(IRequestProvider request)
        {
            dynamic data = new ExpandoObject();
            if (!string.IsNullOrEmpty(request.HostName)) data.HostName = request.HostName;
            if (!string.IsNullOrEmpty(request.Url)) data.Url = request.Url;
            if (!string.IsNullOrEmpty(request.HttpMethod)) data.HttpMethod = request.HttpMethod;
            if (!string.IsNullOrEmpty(request.IPAddress)) data.IPAddress = request.IPAddress;
            if (!string.IsNullOrEmpty(request.Content)) data.Content = request.Content;
            if (request.Headers != null) data.Headers = request.Headers;
            if (request.QueryString != null) data.QueryString = request.QueryString;
            if (request.Form != null) data.Form = request.Form;
            if (request.Data != null) data.Data = request.Data;

            return data;
        }
    }
}