using CalculationService.Core.Models;
using CalculationService.Core.Services.DTOs;

namespace CalculationService.Services;

public interface ICalculationService
{
    public Task<IEnumerable<Calculation>> GetAllCalculations();
    public Task<Calculation> GetCalculationById(int calculationId);
    public Task<Calculation> AddCalculation(AddCalculationDTO addCalculationDto);
    
    public Task RebuildDatabase();
}