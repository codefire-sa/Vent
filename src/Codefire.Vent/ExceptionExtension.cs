using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Codefire.Vent.Models;

namespace Codefire.Vent
{
    public static class ExceptionExtension
    {
        public static IEnumerable<StackTraceData> BuildStackTrace(this Exception ex)
        {
            var lines = new List<StackTraceData>();

            var stackTrace = new StackTrace(ex, true);
            var frames = stackTrace.GetFrames();

            if (frames == null || frames.Length == 0)
            {
                return lines;
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

                    var line = new StackTraceData
                    {
                        FileName = file,
                        LineNumber = lineNumber,
                        MethodName = methodName,
                        ClassName = className
                    };

                    lines.Add(line);
                }
            }

            return lines;
        }

        private static string GenerateMethodName(MethodBase method)
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
    }
}
