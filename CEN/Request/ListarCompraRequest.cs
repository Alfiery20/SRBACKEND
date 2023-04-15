using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class ListarCompraRequest
    {
        public string? CodigoCompra { get; set; }
        public DateTime? FechaMinima { get; set; }
        public DateTime? FechaMaxima { get; set; }
        public string? EstadoCompra { get; set; }
        public int? Pagina { get; set; }
        public int? Cantidad { get; set; }
    }
}
