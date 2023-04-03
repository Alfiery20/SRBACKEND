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
        public double? Peso { get; set; }
        public double? Precio { get; set; }
        public int? id_Categoria { get; set; }
        public string? Ids_etiquetas { get; set; }
        public string? Ids_porc_material{ get; set; }
    }
}
