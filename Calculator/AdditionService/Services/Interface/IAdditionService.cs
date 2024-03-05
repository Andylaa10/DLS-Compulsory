namespace AdditionService.Services;

public interface IAdditionService
{
    public Task<double> Addition(double number1, double number2);
}