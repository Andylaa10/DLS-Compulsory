using CalculationService.Core.Services.DTOs;
using CalculationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationController : ControllerBase
{
    private readonly ICalculationService _calculationService;

    public CalculationController(ICalculationService calculationService)
    {
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
    [Route("AddCalculation")]
    public async Task<IActionResult> AddCalculation([FromBody] AddCalculationDTO dto)
    {
        try
        {
            return Ok(await _calculationService.AddCalculation(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("/rebuild")]
    public async Task<IActionResult> RebuildDatabase()
    {
        try
        {
            await _calculationService.RebuildDatabase();
            return StatusCode(200, "Database recreated");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}