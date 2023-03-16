using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class IUDUsuario
    {
        public int? Id { get; set; }
        public string? NumerDocumento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? ApelliPaterno { get; set; }
        public string? ApelliMaterno { get; set; }
        public string? CorreElectronico { get; set; }
        public string? Clave { get; set; }
        public string? Token { get; set;}
    }
}
