namespace AdditionService.Services;

public class AdditionService : IAdditionService
{
    public async Task<double> Addition(double number1, double number2)
    {
        return await Task.Run(() => number1 + number2);
    }
}