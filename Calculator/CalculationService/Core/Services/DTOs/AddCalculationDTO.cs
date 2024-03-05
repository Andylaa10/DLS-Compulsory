using CalculationService.Core.Models.Enums;

namespace CalculationService.Core.Services.DTOs;

public class AddCalculationDTO
{
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }
    public Operation Operation { get; set; }
}