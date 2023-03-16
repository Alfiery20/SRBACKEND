using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenPrecio
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public double? Monto { get; set; }
        public string? Motivo { get; set; }
        public string? Estado { get; set; }
        public string? FechaRegistro { get; set; }
        public string? FechaEliminacion { get; set; }
    }
}
