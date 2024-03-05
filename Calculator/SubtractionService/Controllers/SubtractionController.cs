using Microsoft.AspNetCore.Mvc;
using SubtractionService.Services.Interfaces;

namespace SubtractionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubtractionController : ControllerBase
{
    private readonly ILogger<SubtractionController> _logger;
    private readonly ISubtractionService _subtractionService;


    public SubtractionController(ILogger<SubtractionController> logger, ISubtractionService subtractionService)
    {
        _logger = logger;
        _subtractionService = subtractionService;
    }

    [HttpGet]
    [Route("{number1}/{number2}")]
    public async Task<IActionResult> Subtraction([FromRoute] double number1, [FromRoute] double number2)
    {
        try
        {
            var result = await _subtractionService.Subtraction(number1, number2);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}