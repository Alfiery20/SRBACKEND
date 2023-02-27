using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class IUDUsuario
    {
        public int id { get; set; }
        public string? numerDocumento { get; set; }
        public string? nombreCompleto { get; set; }
        public string? apelliPaterno { get; set; }
        public string? apelliMaterno { get; set; }
        public string? correElectronico { get; set; }
        public string? clave { get; set; }
        public string? token { get; set;}
    }
}
