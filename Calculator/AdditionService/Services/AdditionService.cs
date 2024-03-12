using Monitoring;

namespace AdditionService.Services;

public class AdditionService : IAdditionService
{
    public async Task<double> Addition(double number1, double number2)
    {
        using var activity = MonitorService.ActivitySource.StartActivity();
        
        MonitorService.Log.Information("Called Subtraction function");
        
        await Serilog.Log.CloseAndFlushAsync();
        
        return await Task.Run(() => number1 + number2);
    }
}