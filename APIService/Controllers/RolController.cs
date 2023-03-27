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
    public class RolController : ControllerBase
    {
        [HttpPost("listarRolesDeUsuario")]
        public IActionResult ListarRolDeUsuario([FromBody] ListarRolDeUsuarioRequest listarRolDeUsuario)
        {
            try
            {
                ClnRol clnRol = new();
                var request = clnRol.ListarRolesDeUsuario(listarRolDeUsuario);
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
