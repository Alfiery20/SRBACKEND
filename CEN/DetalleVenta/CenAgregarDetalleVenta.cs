using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.DetalleVenta
{
    public class CenAgregarDetalleVenta
    {
        public int? Cantidad { get; set; }
        public int? IdProducto { get; set; }
        public double? PrecioVenta { get; set; }
        public int? IdVenta { get; set; }
    }
}
