using CAD;
using CEN.Request;
using CEN.Compra;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnCompra
    {
        public CenControlError ListarCompra(ListarCompraRequest request)
        {
            CadCompra c = new();
            return c.ListarCompras(request);
        }
        public CenControlError ObtenerCompra(int idCompra)
        {
            CadCompra c = new();
            return c.ObtenerCompra(idCompra);
        }
        public CenControlError CambiarAAprobada(CenAgregarCompra request)
        {
            CadCompra c = new();
            return c.AgregarCompra(request);
        }
        public CenControlError CambiarAEnCamino(CenEditarCompra request)
        {
            CadCompra c = new();
            return c.CambiarAEnCamino(request);
        }
        public CenControlError CambiarAFinaliza(CenEditarCompra request)
        {
            CadCompra c = new();
            return c.CambiarAFinalizar(request);
        }
        public CenControlError CambiarARechazada(CenEliminarCompra request)
        {
            CadCompra c = new();
            return c.CambiarARechazada(request);
        }
        public CenControlError CambiarGeneral(CenEditarGeneralCompra request)
        {
            CadCompra c = new();
            return c.CambiarGeneral(request);
        }
    }
}
