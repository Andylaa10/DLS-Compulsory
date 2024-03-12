using CalculationService.Core.Services.DTOs;
using CalculationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationController : ControllerBase
{
    private readonly ILogger<CalculationController> _logger;
    private readonly ICalculationService _calculationService;

    public CalculationController(ILogger<CalculationController> logger, ICalculationService calculationService)
    {
        _logger = logger;
        _calculationService = calculationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCalculations()
    {
        try
        {
            return Ok(await _calculationService.GetAllCalculations());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("/{calId}")]
    public async Task<IActionResult> GetCalculationById([FromRoute] int calId)
    {
        try
        {
            return Ok(await _calculationService.GetCalculationById(calId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCalculation([FromBody] AddCalculationDTO dto)
    {
        try
        {
            await _calculationService.AddCalculation(dto);
            return StatusCode(201, "Calculation successfully added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}