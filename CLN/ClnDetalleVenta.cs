using CAD;
using CEN.Categoria;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.DetalleVenta;

namespace CLN
{
    public class ClnDetalleVenta
    {
        public CenControlError ListarDetalleVenta(ListarDetalleVentaRequest request)
        {
            CadDetalleVenta c = new();
            return c.ListarDetalleVenta(request);
        }
        public CenControlError AgregarDetalleVenta(CenAgregarDetalleVenta AgregarDetalleVenta)
        {
            CadDetalleVenta c = new();
            return c.AgregarDetalleVenta(AgregarDetalleVenta);
        }
        public CenControlError EditarDetalleVenta(CenEditarDetalleVenta EditarDetalleVenta)
        {
            CadDetalleVenta c = new();
            return c.EditarDetalleVenta(EditarDetalleVenta);
        }
        public CenControlError EliminarDetalleVenta(CenEliminarDetalleVenta EliminarDetalleVenta)
        {
            CadDetalleVenta c = new();
            return c.EliminarDetalleVenta(EliminarDetalleVenta);
        }
    }
}
