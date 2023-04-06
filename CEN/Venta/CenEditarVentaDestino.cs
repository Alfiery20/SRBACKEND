using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Venta
{
    public class CenEditarVentaDestino
    {
        public int? Id { get; set; }
        public string? DireccionEntrega { get; set; }
        public int? IdUsuarioEdita { get; set; }
        public int? IdCondado { get; set; }
    }
}
