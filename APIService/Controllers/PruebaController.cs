using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers;

[ApiController]
[Route("[controller]")]
public class PruebaController : ControllerBase
{

    private readonly ILogger<PruebaController> _logger;

    public PruebaController(ILogger<PruebaController> logger)
    {
        _logger = logger;
    }

    [HttpGet("prueba")]
    public async Task<IActionResult> Prueba()
    {
        return Ok("Sumaq Rumi " + new DateTime());
    }
}
