using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenTipoDocumento
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string numeroDocumento { get; set; }
        public string longitudMax { get; set; }
        public string estadoDocumento { get; set; }
    }
}
