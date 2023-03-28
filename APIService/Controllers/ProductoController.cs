using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Producto;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost("listarProductos")]
        public IActionResult ListarProductos([FromBody] ListarProductoRequest listarProductoRequest)
        {
            try
            {
                ClnProducto clnProducto = new ClnProducto();
                var request = clnProducto.ListarProducto(listarProductoRequest);
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

        [HttpPost("agregarProducto")]
        public IActionResult AddProducto([FromBody] CenAgregarProducto AgregarProducto)
        {
            try
            {
                ClnProducto clnProducto = new ClnProducto();
                var request = clnProducto.AgregarProducto(AgregarProducto);
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

        [HttpPut("editarProducto")]
        public IActionResult EditProducto([FromBody] CenEditarProducto EditarProducto)
        {
            try
            {
                ClnProducto clnProducto = new ClnProducto();
                var request = clnProducto.EditarProducto(EditarProducto);
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

        [HttpDelete("eliminarProducto")]
        public IActionResult DelProducto([FromQuery] CenEliminarProducto EliminarProducto)
        {
            try
            {
                ClnProducto clnProducto = new ClnProducto();
                var request = clnProducto.EliminarProducto(EliminarProducto);
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

        [HttpGet("obtenerProducto")]
        public IActionResult ObtenerProducto([FromQuery] int id)
        {
            try
            {
                ClnProducto clnProducto = new ClnProducto();
                var request = clnProducto.ObtenerProducto(id);
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
