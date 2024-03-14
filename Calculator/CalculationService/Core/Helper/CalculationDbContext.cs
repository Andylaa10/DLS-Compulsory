using CalculationService.Core;
using Microsoft.EntityFrameworkCore;
using CalculationService.Core.Models;


namespace ResultService.Core.Helper;

public class CalculationDbContext : DbContext
{
    public CalculationDbContext(DbContextOptions<CalculationDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=calculator-db;Database=CalculatorDb;User Id=sa;Password=SuperSecret7!;Trusted_Connection=False;TrustServerCertificate=True;");        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Setup DB
        //Auto generate id
        modelBuilder.Entity<Calculation>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        //modelBuilder.Entity<Calculation>().Property(c => c.Operation).HasConversion(o => o.ToString(),o => (Operation)Enum.Parse(typeof(Operation), o));

        #endregion

    }

    public DbSet<Calculation> Calculations { get; set; }
}