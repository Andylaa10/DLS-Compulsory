using System.Diagnostics;
using System.Reflection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.Span;
using ILogger = Serilog.ILogger;

namespace Monitoring;

public class Logging
{
    public static ILogger Log => Serilog.Log.Logger;
    
    static Logging()
    {
        // Serilog
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Seq("http://seq:5341")
            .WriteTo.Console()
            .Enrich.WithSpan()
            .CreateLogger();
    }
}