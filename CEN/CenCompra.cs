using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenCompra
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string fechaSolicitud { get; set; }
        public string fechaEntrega { get; set; }
        public string direccionEntrega { get; set; }
        public int idCondado { get; set; }
    }
}
