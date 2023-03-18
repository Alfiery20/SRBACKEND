using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Helpers
{
    public class Paginado
    {
        public int? Pagina { get; set; }
        public int? Tamanio { get; set; }
        public int? Total_Resultados { get; set; }
        public Object? Data { get; set; }

    }
}
