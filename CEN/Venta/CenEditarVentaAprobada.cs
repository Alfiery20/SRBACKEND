using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Venta
{
    public class CenEditarVentaAprobada
    {
        public int? Id { get; set; }
        public int? IdUsuarioAprueba { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
