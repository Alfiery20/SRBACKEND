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
        public CenProducto? Producto { get; set; }
        public CenCategoria? Categoria { get; set; }
    }
}
