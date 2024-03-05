namespace SubtractionService.Services.Interfaces;

public interface ISubtractionService
{
    public Task<double> Subtraction(double number1, double number2);
}