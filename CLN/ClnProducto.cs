using CAD;
using CEN.Producto;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnProducto
    {
        public CenControlError ListarProducto(ListarProductoRequest request)
        {
            CadProducto c = new();
            return c.ListarProducto(request);
        }
        public CenControlError AgregarProducto(CenAgregarProducto request)
        {
            CadProducto c = new();
            return c.AgregarProducto(request);
        }
        public CenControlError EditarProducto(CenEditarProducto request)
        {
            CadProducto c = new();
            return c.EditarProducto(request);
        }
        public CenControlError EliminarProducto(CenEliminarProducto request)
        {
            CadProducto c = new();
            return c.EliminarProducto(request);
        }
        public CenControlError ObtenerProducto(int id)
        {
            CadProducto c = new();
            return c.ObtenerProducto(id);
        }
    }
}
