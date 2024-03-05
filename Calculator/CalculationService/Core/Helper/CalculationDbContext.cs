using CalculationService.Core;
using Microsoft.EntityFrameworkCore;
using CalculationService.Core.Models;

namespace ResultService.Core.Helper;

public class CalculationDbContext : DbContext
{
    public CalculationDbContext(DbContextOptions<CalculationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Setup DB
        //Auto generate id
        modelBuilder.Entity<Calculation>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        #endregion
        
    }

    public DbSet<Calculation> Calculations { get; set; }
}