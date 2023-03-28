using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Etiqueta;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        [HttpPost("listarEtiquetas")]
        public IActionResult ListarEtiquetas([FromBody] ListarEtiquetaRequest listarEtiquetaRequest)
        {
            try
            {
                ClnEtiqueta clnEtiqueta = new ClnEtiqueta();
                var request = clnEtiqueta.ListarEtiqueta(listarEtiquetaRequest);
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

        [HttpPost("agregarEtiqueta")]
        public IActionResult AddEtiqueta([FromBody] CenAgregarEtiqueta AgregarEtiqueta)
        {
            try
            {
                ClnEtiqueta clnEtiqueta = new ClnEtiqueta();
                var request = clnEtiqueta.AgregarEtiqueta(AgregarEtiqueta);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpPut("editarEtiqueta")]
        public IActionResult EditEtiqueta([FromBody] CenEditarEtiqueta EditarEtiqueta)
        {
            try
            {
                ClnEtiqueta clnEtiqueta = new ClnEtiqueta();
                var request = clnEtiqueta.EditarEtiqueta(EditarEtiqueta);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpDelete("eliminarEtiqueta")]
        public IActionResult DelEtiqueta([FromQuery] CenEliminarEtiqueta EliminarEtiqueta)
        {
            try
            {
                ClnEtiqueta clnEtiqueta = new ClnEtiqueta();
                var request = clnEtiqueta.EliminarEtiqueta(EliminarEtiqueta);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpGet("obtenerEtiqueta")]
        public IActionResult ObtenerEtiqueta([FromQuery] int id)
        {
            try
            {
                ClnEtiqueta clnEtiqueta = new ClnEtiqueta();
                var request = clnEtiqueta.ObtenerEtiqueta(id);
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
