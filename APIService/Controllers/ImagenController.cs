using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CEN.Imagen;
using Services.Imgs;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        [HttpPost("listarImagens")]
        public IActionResult ListarImagens([FromBody] ListarImagenesRequest listarImagenRequest)
        {
            try
            {
                ClnImagen clnImagen = new();
                var request = clnImagen.ListarImagen(listarImagenRequest);
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

        [HttpPost("agregarImagen")]
        [Consumes("multipart/form-data")]
        public IActionResult AddImagen([FromQuery] string descripcion, [FromQuery] int idProducto, IFormFile imagen)
        {
            try
            {
                ClnImagen clnImagen = new();
                string date = DateTime.Now.ToString("MM-dd-yyyy_hh:mm");
                string nombre = "SumaqRumi_" + (clnImagen.ObtenerCodigo(idProducto) + 1) + "_" + date;
                int respuesta = CloudinayConexion.SubirArchivo(imagen, nombre);
                CenAgregarImagen agregarimagen = new();
                if (respuesta == 1)
                {
                    var request = clnImagen.AgregarImagen(agregarimagen = new()
                    {
                        Descripcion = descripcion,
                        NombreOriginal = imagen.FileName,
                        NombrePresenta = nombre
                    });
                    if (request.Codigo != "OK")
                    {
                        CloudinayConexion.EliminarArchivo(nombre);
                    }
                }
                return Ok(Request);
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

        [HttpDelete("eliminarImagen")]
        public IActionResult DelImagen([FromQuery] CenEliminarImagen EliminarImagen)
        {
            try
            {
                ClnImagen clnImagen = new ClnImagen();
                var request = clnImagen.EliminarImagen(EliminarImagen);
                if (request.Codigo == "OK")
                {
                    var Respuesta = CloudinayConexion.EliminarArchivo(EliminarImagen.Nombre);
                }
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

        [HttpGet("obtenerImagen")]
        public IActionResult ObtenerImagen([FromQuery] int id)
        {
            try
            {
                ClnImagen clnImagen = new ClnImagen();
                var request = clnImagen.ObtenerImagen(id);
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
