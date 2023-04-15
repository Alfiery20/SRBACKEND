using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Compra
{
    public class CenAgregarCompra
    {
        public double? CostoCompra { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int idUsuarioInserta { get; set; }
    }
}
