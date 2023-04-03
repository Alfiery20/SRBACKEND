using CEN.Categoria;
using CEN.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN.Response
{
    public class ProductoResponse
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public string? Estado { get; set; }
        public double? Peso { get; set; }
        public double? Precio { get; set; }
        public int? Id_Categoria { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
