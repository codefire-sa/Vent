using System;
using System.Dynamic;
using System.Reflection;

namespace Codefire.Vent
{
    public class VentConfiguration : IVentConfiguration
    {
        private static readonly Lazy<string> ApplicationVersion = new Lazy<string>(() =>
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null) return "Not supplied";

            return entryAssembly.GetName().Version.ToString();
        });

        public VentConfiguration()
        {
            MachineNameProvider = () => Environment.MachineName;
            VersionProvider = () => ApplicationVersion.Value;
            EnvironmentProvider = CreateEnvironment;
        }

        public string Source { get; set; }
        public Func<string> MachineNameProvider { get; set; }
        public Func<string> UserNameProvider { get; set; }
        public Func<string> VersionProvider { get; set; }
        public Func<dynamic> EnvironmentProvider { get; set; }

        private dynamic CreateEnvironment()
        {
            var data = new ExpandoObject();

            return data;
        }
    }
}