using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Categoria;
using Microsoft.AspNetCore.Authorization;
using CEN.Venta;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("CrearCarrito")]
        public IActionResult ListarCategorias([FromBody] CenAgregarVenta AgregarVenta)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CrearCarritoCompras(AgregarVenta);
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
        [HttpPut("SolicitarVenta")]
        public IActionResult ModificarVentaAPendiente([FromBody] CenEditarVentaPendiente EditarVentaPendiente)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarAPendiente(EditarVentaPendiente);
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
        [HttpPut("AprobarVenta")]
        public IActionResult AprobarVenta([FromBody] CenEditarVentaAprobada EditarVentaAprobada)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarAAprobada(EditarVentaAprobada);
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
        [HttpPut("EnviarVenta")]
        public IActionResult ModificarVentaAEnCamino([FromBody] CenEditaVentaEnCamino EditaVentaEnCamino)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarAEnCamino(EditaVentaEnCamino);
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
        [HttpPut("FinalizarVenta")]
        public IActionResult FinalizarVenta([FromBody] CenEditaVentaFinaliza EditaVentaFinaliza)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarAFinaliza(EditaVentaFinaliza);
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
        [HttpPut("ModificarDireccion")]
        public IActionResult EditarDireccion([FromBody] CenEditarVentaDestino EditarVentaDestino)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarDestino(EditarVentaDestino);
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
        [HttpDelete("RechazarVenta")]
        public IActionResult EliminarVenta([FromQuery] CenEditarVentaRechazar EditarVentaRechazar)
        {
            try
            {
                ClnVenta ClnVenta = new();
                var request = ClnVenta.CambiarARechazar(EditarVentaRechazar);
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
