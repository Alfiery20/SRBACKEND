using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenCompra
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? FechaEntrega { get; set; }
        public string? DireccionEntrega { get; set; }
        public int? IdCondado { get; set; }
    }
}
