using SubtractionService.Services.Interfaces;

namespace SubtractionService.Services;

public class SubtractionService : ISubtractionService
{
    public async Task<double> Subtraction(double number1, double number2)
    {
        return await Task.Run(() => number1 - number2);
    }
}