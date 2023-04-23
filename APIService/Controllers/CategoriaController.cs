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
    public class CategoriaController : ControllerBase
    {
        [HttpPost("listarCategorias")]
        public IActionResult ListarCategorias([FromBody] ListarCategoriaRequest listarCategoriaRequest)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.ListarCategoria(listarCategoriaRequest);
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
        [HttpPost("agregarCategoria")]
        public IActionResult AddCategoria([FromBody] CenAgregarCategoria AgregarCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.AgregarCategoria(AgregarCategoria);
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
        [HttpPut("editarCategoria")]
        public IActionResult EditCategoria([FromBody] CenEditarCategoria EditarCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.EditarCategoria(EditarCategoria);
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
        [HttpDelete("eliminarCategoria")]
        public IActionResult DelCategoria([FromQuery] CenEliminarCategoria EliminarCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.EliminarCategoria(EliminarCategoria);
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
        [HttpGet("obtenerCategoria")]
        public IActionResult ObtenerCategoria([FromQuery] int id)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.ObtenerCategoria(id);
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
