using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SubtractionService.Services.Interfaces;

namespace SubtractionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubtractionController : ControllerBase
{
    private readonly ILogger<SubtractionController> _logger;
    private readonly ISubtractionService _subtractionService;
    private HttpClient _httpClient = new();



    public SubtractionController(ILogger<SubtractionController> logger, ISubtractionService subtractionService)
    {
        _logger = logger;
        _subtractionService = subtractionService;
    }

    [HttpGet]
    [Route("{firstNumber}/{secondNumber}")]
    public async Task<IActionResult> Subtraction([FromRoute] double firstNumber, [FromRoute] double secondNumber)
    {
        try
        {
            var result = await _subtractionService.Subtraction(firstNumber, secondNumber);
            
            //This means subtraction
            var operation = 1;
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