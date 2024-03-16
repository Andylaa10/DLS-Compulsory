using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Polly;
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
            
            var polly = Policy.Handle<HttpRequestException>().Retry(3, (ex, retryCount) =>
            {
                Console.WriteLine($"Retrying due to {ex.GetType().Name}... Attempt {retryCount}");
            });
            
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

            polly.Execute(() =>
            {
                _httpClient.PostAsync("http://Calculator/api/Calculation/AddCalculation", content);
            });            
            
            await Task.Delay(200);

            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}