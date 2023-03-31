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
        [HttpPost("listarImagenes")]
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
        public IActionResult AddImagen([FromForm] CenAgregarFichero cenAgregarFichero)
        {
            try
            {
                ClnImagen clnImagen = new();
                string date = DateTime.Now.ToString("MM-dd-yyyy_hh:mm");
                string nombre = "SumaqRumi_" + (clnImagen.ObtenerCodigo(cenAgregarFichero.IdProducto) + 1) + "_" + date;
                int respuesta = CloudinayConexion.SubirArchivo(cenAgregarFichero.File, nombre);
                CenAgregarImagen agregarimagen = new();
                if (respuesta == 1)
                {
                    agregarimagen = new()
                    {
                        Descripcion = cenAgregarFichero.Descripcion,
                        NombreOriginal = cenAgregarFichero.File.FileName,
                        NombrePresenta = nombre,
                        IdProducto = cenAgregarFichero.IdProducto
                    };
                    var request = clnImagen.AgregarImagen(agregarimagen);
                    if (request.Codigo != "OK")
                    {
                        CloudinayConexion.EliminarArchivo(nombre);
                    }
                    return Ok(request);
                }
                else
                {
                    ClnControlError obj = new ClnControlError();
                    var error = new CenControlError
                    {
                        Tipo = "C",
                        Descripcion = "Error en insercion de imagen"
                    };
                    obj.InsertControlError(error);
                    return BadRequest(error);
                }
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
        public IActionResult DelImagen([FromQuery] CenEliminarImagen cenEliminarImagen)
        {
            try
            {
                ClnImagen clnImagen = new ClnImagen();
                var request = clnImagen.EliminarImagen(cenEliminarImagen);
                if (request.Codigo == "OK")
                {
                    var Respuesta = CloudinayConexion.EliminarArchivo(cenEliminarImagen.Nombre);
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
