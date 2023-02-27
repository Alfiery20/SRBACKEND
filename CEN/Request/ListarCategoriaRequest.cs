using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Request
{
    public class ListarCategoriaRequest
    {
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? tipoBusqueda { get; set; }
        public int pagina { get; set; }
        public int cantidad { get; set; }
    }
}
