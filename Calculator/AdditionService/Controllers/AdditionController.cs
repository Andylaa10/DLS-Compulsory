using System.Text;
using System.Text.Json;
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
    private HttpClient _httpClient = new();

    public AdditionController(ILogger<AdditionController> logger, IAdditionService additionService)
    {
        _logger = logger;
        _additionService = additionService;
    }

    [HttpGet]
    [Route("{firstNumber}/{secondNumber}")]
    public async Task<IActionResult> Addition([FromRoute] double firstNumber, [FromRoute] double secondNumber)
    {
        try
        {
            var result = await _additionService.Addition(firstNumber, secondNumber);

            //This means addition
            var operation = 0;
            var dto = new
            {
                firstNumber,
                secondNumber,
                result,
                operation
            };

            var payload = JsonSerializer.Serialize(dto);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            _httpClient.PostAsync("http://Calculator/api/Calculation/AddCalculation", content);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}