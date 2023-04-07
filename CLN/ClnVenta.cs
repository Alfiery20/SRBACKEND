using CAD;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Venta;

namespace CLN
{
    public class ClnVenta
    {
        public CenControlError ListarVenta(ListarVentaRequest request)
        {
            CadVenta c = new();
            return c.ListarVentas(request);
        }
        public CenControlError CrearCarritoCompras(CenAgregarVenta request)
        {
            CadVenta c = new();
            return c.CrearCarritoCompras(request);
        }
        public CenControlError CambiarAPendiente(CenEditarVentaPendiente request)
        {
            CadVenta c = new();
            return c.CambiarAPendiente(request);
        }
        public CenControlError CambiarAAprobada(CenEditarVentaAprobada request)
        {
            CadVenta c = new();
            return c.CambiarAAprobada(request);
        }
        public CenControlError CambiarAEnCamino(CenEditaVentaEnCamino request)
        {
            CadVenta c = new();
            return c.CambiarAEnCamino(request);
        }
        public CenControlError CambiarAFinaliza(CenEditaVentaFinaliza request)
        {
            CadVenta c = new();
            return c.CambiarAFinaliza(request);
        }
        public CenControlError CambiarDestino(CenEditarVentaDestino request)
        {
            CadVenta c = new();
            return c.CambiarDestino(request);
        }
        public CenControlError CambiarARechazar(CenEditarVentaRechazar request)
        {
            CadVenta c = new();
            return c.CambiarARechazar(request);
        }
    }
}
