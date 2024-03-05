using AdditionService.Services;
using Microsoft.AspNetCore.Mvc;
using Monitoring;

namespace AdditionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdditionController : ControllerBase
{
    private readonly ILogger<AdditionController> _logger;
    private readonly IAdditionService _additionService;

    public AdditionController(ILogger<AdditionController> logger, IAdditionService additionService)
    {
        _logger = logger;
        _additionService = additionService;
    }

    [HttpGet]
    [Route("{number1}/{number2}")]
    public async Task<IActionResult> Addition([FromRoute] double number1, [FromRoute] double number2)
    {
        try
        {
            var result = await _additionService.Addition(number1, number2);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}