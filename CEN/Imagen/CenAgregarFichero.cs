using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Imagen
{
    public class CenAgregarFichero
    {
        public string? Descripcion { get; set; }
        public int IdProducto { get; set; }
        public IFormFile File { get; set; }
    }
}
