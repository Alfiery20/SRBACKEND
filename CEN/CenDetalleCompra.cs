using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenDetalleCompra
    {
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public double? subtotal { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCompra { get; set; }
    }
}
