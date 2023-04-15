using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Categoria;
using Microsoft.AspNetCore.Authorization;
using CEN.Compra;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpPost("ListarCompra")]
        public IActionResult ListarCompras([FromBody] ListarCompraRequest ListarCompra)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.ListarCompra(ListarCompra);
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
        [HttpPost("AgregarCompra")]
        public IActionResult AprobarCompra([FromBody] CenAgregarCompra EditarCompraAprobada)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.CambiarAAprobada(EditarCompraAprobada);
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
        [HttpPut("EnviarCompra")]
        public IActionResult ModificarCompraAEnCamino([FromBody] CenEditarCompra EditaCompraEnCamino)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.CambiarAEnCamino(EditaCompraEnCamino);
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
        [HttpPut("FinalizarCompra")]
        public IActionResult FinalizarCompra([FromBody] CenEditarCompra EditaCompraFinaliza)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.CambiarAFinaliza(EditaCompraFinaliza);
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
        [HttpPut("ModificarGeneral")]
        public IActionResult EditarDireccion([FromBody] CenEditarGeneralCompra EditarGeneralCompra)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.CambiarGeneral(EditarGeneralCompra);
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
        [HttpDelete("RechazarCompra")]
        public IActionResult EliminarCompra([FromQuery] CenEliminarCompra EditarCompraRechazar)
        {
            try
            {
                ClnCompra ClnCompra = new();
                var request = ClnCompra.CambiarARechazada(EditarCompraRechazar);
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
