using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenTipoDocumento
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? LongitudMax { get; set; }
        public string? EstadoDocumento { get; set; }
    }
}
