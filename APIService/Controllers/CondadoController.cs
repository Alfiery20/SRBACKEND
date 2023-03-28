using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Categoria;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondadoController : ControllerBase
    {
        [HttpPost("listarCondado")]
        public IActionResult ListarCategorias([FromBody] ListarCondadoRequest condadoRequest)
        {
            try
            {
                ClnCondado clnCondado = new();
                var request = clnCondado.ListarCondado(condadoRequest);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "R",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
    }
}
