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
        string textoSinEncriptar = "Mi texto a encriptar";
        string textoEncriptado = EncrypAES.EncryptStringAES(textoSinEncriptar, Constants.clave_encriptacion);

        string textoDesencriptado = EncrypAES.DecryptStringAES(textoEncriptado, Constants.clave_encriptacion);
        Console.WriteLine("Texto desencriptado: " + textoDesencriptado);
        Console.WriteLine("Texto encriptado: " + textoEncriptado);
        var arr = new { textoEncriptado,  textoDesencriptado};
        return Ok(arr);
    }
}
