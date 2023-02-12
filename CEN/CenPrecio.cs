using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenPrecio
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public double monto { get; set; }
        public string motivo { get; set; }
        public string estado { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaEliminacion { get; set; }
    }
}
