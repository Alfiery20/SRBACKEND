using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Usuario
{
    public class CenUsuario
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Estado { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Clave { get; set; }
        public string? Token { get; set; }
    }
}
