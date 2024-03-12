using Monitoring;
using OpenTelemetry.Trace;
using SubtractionService.Services.Interfaces;

namespace SubtractionService.Services;

public class SubtractionService : ISubtractionService
{
    
    private Tracer _tracer;
    
    public SubtractionService(Tracer tracer)
    {
        _tracer = tracer;
    }
    public async Task<double> Subtraction(double number1, double number2)
    {
        using var activity = _tracer.StartActiveSpan("Subtraction");
        
        Logging.Log.Information("Called Subtraction function");

        return await Task.Run(() => number1 - number2);
    }
}