using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.DetalleVenta
{
    public class CenDetalleVenta
    {
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public double? subtotal { get; set; }
        public int? IdProducto { get; set; }
        public int? IdVenta { get; set; }
    }
}
