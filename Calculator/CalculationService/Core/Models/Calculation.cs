using CalculationService.Core.Models.Enums;

namespace CalculationService.Core.Models;

public class Calculation
{
    public int Id { get; set; }
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }
    public Operation Operation { get; set; }
    public double Result { get; set; }
    public DateTime CalculatedAt { get; set; } = DateTime.Now;
}

