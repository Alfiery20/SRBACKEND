using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Categoria;
using Microsoft.AspNetCore.Authorization;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet("listarMenuCategori")]
        public IActionResult ListarMenuCategoria()
        {
            try
            {
                ClnMenu ClnMenu = new();
                var request = ClnMenu.ListarMenuCategoria();
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
        [HttpGet("listarMenuMaterial")]
        public IActionResult ListarMenuMaterial()
        {
            try
            {
                ClnMenu ClnMenu = new();
                var request = ClnMenu.ListarMenuMaterial();
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
