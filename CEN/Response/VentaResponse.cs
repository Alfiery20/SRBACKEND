using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Response
{
    public class VentaResponse
    {
        public int? IdVenta { get; set; }
        public string? CodigoVenta { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public int? IdUsuarioAprueba { get; set; }
        public string? NombreAprueba { get; set; }
        public int? IdUsuarioEdita { get; set; }
        public string? NombreEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? DireccionEntrega { get; set; }
        public string? EstadoVenta { get; set; }
        public int? IdCondado { get; set; }
    }
}
