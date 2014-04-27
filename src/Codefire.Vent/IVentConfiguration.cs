using System;

namespace Codefire.Vent
{
    public interface IVentConfiguration
    {
        string Source { get; set; }
        Func<string> MachineNameProvider { get; set; }
        Func<string> UserNameProvider { get; set; }
        Func<string> VersionProvider { get; set; }
        Func<dynamic> EnvironmentProvider { get; set; }
    }
}