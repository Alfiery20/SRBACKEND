using CEN.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Encrypt;
using System.Security.Cryptography;

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
        var respuesta = "BIENVENIDO A LA API DE SUMAQ RUMI";
        return Ok(respuesta);
    }
}

