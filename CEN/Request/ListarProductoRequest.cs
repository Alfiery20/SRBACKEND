using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class ListarProductoRequest
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public double? PrecioMinimo { get; set; }
        public double? PrecioMax { get; set; }
        public int? idCategoria { get; set; }
        public int? idMaterial { get; set; }
        public int? Pagina { get; set; }
        public int? Cantidad { get; set; }
    }
}
