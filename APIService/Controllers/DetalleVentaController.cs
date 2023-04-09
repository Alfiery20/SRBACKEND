using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Categoria;
using Microsoft.AspNetCore.Authorization;
using CEN.DetalleVenta;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        [HttpPost("listarDetalleVenta")]
        public IActionResult ListarDetalleVenta([FromBody] ListarDetalleVentaRequest ListarDetalle)
        {
            try
            {
                ClnDetalleVenta clnDetalleVenta = new();
                var request = clnDetalleVenta.ListarDetalleVenta(ListarDetalle);
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

        [HttpPost("agregarDetalleVenta")]
        public IActionResult AgregarDetalleVenta([FromBody] CenAgregarDetalleVenta AgregarDetalleVenta)
        {
            try
            {
                ClnDetalleVenta clnDetalleVenta = new();
                var request = clnDetalleVenta.AgregarDetalleVenta(AgregarDetalleVenta);
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

        [HttpPut("editarDetalleVenta")]
        public IActionResult EditDetalleVenta([FromBody] CenEditarDetalleVenta EditarDetalleVenta)
        {
            try
            {
                ClnDetalleVenta clnDetalleVenta = new();
                var request = clnDetalleVenta.EditarDetalleVenta(EditarDetalleVenta);
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

        [HttpDelete("eliminarDetalleVenta")]
        public IActionResult EliminarDetalleVenta([FromQuery] CenEliminarDetalleVenta EliminarDetalleVenta)
        {
            try
            {
                ClnDetalleVenta clnDetalleVenta = new();
                var request = clnDetalleVenta.EliminarDetalleVenta(EliminarDetalleVenta);
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
    }
}
