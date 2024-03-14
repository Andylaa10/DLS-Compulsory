using CalculationService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Monitoring;
using OpenTelemetry.Trace;
using ResultService.Core.Helper;
using ResultService.Core.Repositories.Interfaces;

namespace ResultService.Core.Repositories;

public class CalculationRepository : ICalculationRepository
{
    private readonly CalculationDbContext _context;
    private Tracer _tracer;
    
    public CalculationRepository(CalculationDbContext context, Tracer tracer)
    {
        _context = context;
        _tracer = tracer;
    }

    public async Task<IEnumerable<Calculation>> GetAllCalculations()
    {
        using var activity = _tracer.StartActiveSpan("GetAllCalculations");
        
        Logging.Log.Information("Called GetAllCalculations function");

        return await _context.Calculations.ToListAsync();
    }

    public async Task<Calculation> GetCalculationById(int calculationId)
    {
        using var activity = _tracer.StartActiveSpan("GetCalculationById");
        
        Logging.Log.Information("Called GetCalculationById function");
        
        return await _context.Calculations.FirstOrDefaultAsync(c => c.Id == calculationId);
    }

    public async Task AddCalculation(Calculation calculation)
    {
        using var activity = _tracer.StartActiveSpan("AddCalculationToDB");
        
        Logging.Log.Information("AddCalculationToDB");
        
        // await _context.Database.BeginTransactionAsync(); TODO FIND OUT HOW TO DO THIS
        await _context.Calculations.AddAsync(calculation);
        await _context.SaveChangesAsync();
    }
    
    public async Task RebuildDatabase()
    { 
        using var activity = _tracer.StartActiveSpan("Rebuild DB");
        
        Logging.Log.Information("Called RebuildDatabase function");

        await _context.Database.EnsureDeletedAsync(); 
        await _context.Database.EnsureCreatedAsync();
    }
}