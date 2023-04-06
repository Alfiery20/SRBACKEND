using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Venta
{
    public class CenVenta
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public int? IdUsuarioAprueba { get; set; }
        public DateTime? FechaAprueba { get; set; }
        public int? IdUsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? DireccionEntrega { get; set; }
        public string? EstadoVenta { get; set; }
        public int? IdCondado { get; set; }
    }
}
