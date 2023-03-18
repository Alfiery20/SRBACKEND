using CAD;
using CEN.TipoDocumento;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnTipoDocumento
    {
        public CenControlError ListarTipoDocumento(ListarTipoDocumentoRequest request)
        {
            CadTipoDocumento c = new CadTipoDocumento();
            return c.ListarTipoDocumento(request);
        }
        public CenControlError AgregarTipoDocumento(CenAgregarTipoDocumento request)
        {
            CadTipoDocumento c = new CadTipoDocumento();
            return c.AgregarTipoDocumento(request);
        }
        public CenControlError EditarTipoDocumento(CenEditarTipoDocumento request)
        {
            CadTipoDocumento c = new CadTipoDocumento();
            return c.EditarTipoDocumento(request);
        }
        public CenControlError EliminarTipoDocumento(CenEliminarTipoDocumento request)
        {
            CadTipoDocumento c = new CadTipoDocumento();
            return c.EliminarTipoDocumento(request);
        }
        public CenControlError ObtenerTipoDocumento(int id)
        {
            CadTipoDocumento c = new();
            return c.ObtenerTipoDocumento(id);
        }
    }
}
