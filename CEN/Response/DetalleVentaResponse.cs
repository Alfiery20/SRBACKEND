using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Response
{
    public class DetalleVentaResponse
    {
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public int? IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public double Subtotal { get; set; }
        public double? PrecioVenta { get; set; }
    }
}
