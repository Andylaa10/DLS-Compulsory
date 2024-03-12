using System.Diagnostics;
using Monitoring;
using OpenTelemetry.Trace;

namespace AdditionService.Services;

public class AdditionService : IAdditionService
{
    private Tracer _tracer;
    
    public AdditionService(Tracer tracer)
    {
        _tracer = tracer;
    }
    public async Task<double> Addition(double number1, double number2)
    {
        using var activity = _tracer.StartActiveSpan("Addition");
        
        Logging.Log.Information("Called Addition function");
        
        return await Task.Run(() => number1 + number2);
    }
}