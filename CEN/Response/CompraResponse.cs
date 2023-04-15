using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Response
{
    public class CompraResponse
    {
        public int? IdCompra { get; set; }
        public string? CodigoCompra { get; set; }
        public int? Cantidad { get; set; }
        public double? CostoCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public int? IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public int? IdUsuarioInserta { get; set; }
        public string? NombreUsuarioInserta { get; set; }
        public DateTime? FechaEdita { get; set; }
        public int? IdUsuarioEdita { get; set; }
        public string? NombreUsuarioEdita { get; set; }
        public DateTime? FechaEliminar { get; set; }
        public int? IdUsuarioElimina { get; set; }
        public string? NombreUsuarioElimina { get; set; }
        public string? EstadoCompra { get; set; }
    }
}
