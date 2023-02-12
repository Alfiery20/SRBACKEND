using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenDetalleCompra
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
        public int idProducto { get; set; }
        public int idCompra { get; set; }
    }
}
