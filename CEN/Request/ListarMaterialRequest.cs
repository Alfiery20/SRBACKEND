using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class ListarMaterialRequest
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int? Pagina { get; set; }
        public int? Cantidad { get; set; }
    }
}
