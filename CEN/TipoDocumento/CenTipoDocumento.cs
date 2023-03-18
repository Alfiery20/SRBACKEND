using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.TipoDocumento
{
    public class CenTipoDocumento
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int? LongitudMax { get; set; }
        public string? EstadoDocumento { get; set; }
    }
}
