using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Compra
{
    public class CenCompra
    {
        public int IdCompra { get; set; }
        public string? CodigoCompra { get; set; }
        public double? CostoCompra { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdProducto { get; set; }
        public int idUsuarioInserta { get; set; }
        public DateTime FechaEdita { get; set; }
        public int idUsuarioEdita { get; set; }
        public DateTime FechaElimina { get; set; }
        public int idUsuarioElimina { get; set; }
        public string? EstadoCompra { get; set; }
    }
}
