using Monitoring;
using SubtractionService.Services.Interfaces;

namespace SubtractionService.Services;

public class SubtractionService : ISubtractionService
{
    public async Task<double> Subtraction(double number1, double number2)
    {
        using var activity = MonitorService.ActivitySource.StartActivity();
        
        MonitorService.Log.Debug("Called Subtraction function");

        return await Task.Run(() => number1 - number2);
    }
}