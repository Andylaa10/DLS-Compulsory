using CalculationService.Core.Models;

namespace ResultService.Core.Repositories.Interfaces;

public interface ICalculationRepository
{
    public Task<IEnumerable<Calculation>> GetAllCalculations();
    public Task<Calculation> GetCalculationById(int calculationId);
    public Task AddCalculation(Calculation calculation);
    
    public Task RebuildDatabase();
}