using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenUsuario
    {
        public int id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? apellidoPaterno { get; set;}
        public string? apellidoMaterno { get; set; }
        public string? estado { get; set; }
        public string? correoElectronico { get; set; }
        public string? clave { get; set; }
        public string? token { get; set; }
    }
}
