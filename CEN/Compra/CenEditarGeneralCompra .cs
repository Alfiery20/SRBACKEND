using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Compra
{
    public class CenEditarGeneralCompra
    {
        public int IdCompra { get; set; }
        public double? CostoCompra { get; set; }
        public int Cantidad { get; set; }
        public int idUsuarioEdita { get; set; }
    }
}
