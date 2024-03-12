using CalculationService.Core.Models;
using Microsoft.EntityFrameworkCore;
using ResultService.Core.Helper;
using ResultService.Core.Repositories.Interfaces;

namespace ResultService.Core.Repositories;

public class CalculationRepository : ICalculationRepository
{
    private readonly CalculationDbContext _context;

    public CalculationRepository(CalculationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Calculation>> GetAllCalculations()
    {
        return await _context.Calculations.ToListAsync();
    }

    public async Task<Calculation> GetCalculationById(int calculationId)
    {
        return await _context.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
    }

    public async Task AddCalculation(Calculation calculation)
    {
        // await _context.Database.BeginTransactionAsync(); TODO FIND OUT HOW TO DO THIS
        await _context.Calculations.AddAsync(calculation);
        await _context.SaveChangesAsync();
    }
    
    public async Task RebuildDatabase()
    { 
        await _context.Database.EnsureDeletedAsync(); 
        await _context.Database.EnsureCreatedAsync();
    }
}