using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.TipoDocumento;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        [HttpPost("listarTipoDocumentos")]
        public IActionResult ListarTipoDocumentos([FromBody] ListarTipoDocumentoRequest listarTipoDocumentoRequest)
        {
            try
            {
                ClnTipoDocumento clnTipoDocumento = new ClnTipoDocumento();
                var request = clnTipoDocumento.ListarTipoDocumento(listarTipoDocumentoRequest);
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

        [HttpPost("agregarTipoDocumento")]
        public IActionResult AddTipoDocumento([FromBody] CenAgregarTipoDocumento AgregarTipoDocumento)
        {
            try
            {
                ClnTipoDocumento clnTipoDocumento = new ClnTipoDocumento();
                var request = clnTipoDocumento.AgregarTipoDocumento(AgregarTipoDocumento);
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

        [HttpPut("editarTipoDocumento")]
        public IActionResult EditTipoDocumento([FromBody] CenEditarTipoDocumento EditarTipoDocumento)
        {
            try
            {
                ClnTipoDocumento clnTipoDocumento = new ClnTipoDocumento();
                var request = clnTipoDocumento.EditarTipoDocumento(EditarTipoDocumento);
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

        [HttpDelete("eliminarTipoDocumento")]
        public IActionResult DelTipoDocumento([FromBody] CenEliminarTipoDocumento EliminarTipoDocumento)
        {
            try
            {
                ClnTipoDocumento clnTipoDocumento = new ClnTipoDocumento();
                var request = clnTipoDocumento.EliminarTipoDocumento(EliminarTipoDocumento);
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

        [HttpGet("obtenerTipoDocumento")]
        public IActionResult ObtenerTipoDocumento([FromQuery] int id)
        {
            try
            {
                ClnTipoDocumento clnTipoDocumento = new ClnTipoDocumento();
                var request = clnTipoDocumento.ObtenerTipoDocumento(id);
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
