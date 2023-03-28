using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Producto
{
    public class CenAgregarProducto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public double? Peso { get; set; }
        public double? Precio { get; set; }
        public int? id_Categoria { get; set; }
        public string? ids_etiquetas { get; set; }
    }
}
