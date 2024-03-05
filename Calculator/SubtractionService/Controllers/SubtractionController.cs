using Microsoft.AspNetCore.Mvc;

namespace SubtractionService.Controllers;

[ApiController]
[Route("[controller]")]
public class SubtractionController : ControllerBase
{
    private readonly ILogger<SubtractionController> _logger;

    public SubtractionController(ILogger<SubtractionController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public object Get()
    {
        return new();
    }
}