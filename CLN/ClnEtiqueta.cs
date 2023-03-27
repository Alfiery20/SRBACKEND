using CAD;
using CEN.Etiqueta;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Request;

namespace CLN
{
    public class ClnEtiqueta
    {
        public CenControlError ListarEtiqueta(ListarEtiquetaRequest request)
        {
            CadEtiqueta c = new();
            return c.ListarEtiquetas(request);
        }
        public CenControlError ObtenerEtiqueta(int id)
        {
            CadEtiqueta c = new();
            return c.ObtenerEtiqueta(id);
        }
        public CenControlError AgregarEtiqueta(CenAgregarEtiqueta request)
        {
            CadEtiqueta c = new();
            return c.AgregarEtiqueta(request);
        }
        public CenControlError EditarEtiqueta(CenEditarEtiqueta request)
        {
            CadEtiqueta c = new();
            return c.EditarEtiqueta(request);
        }
        public CenControlError EliminarEtiqueta(CenEliminarEtiqueta request)
        {
            CadEtiqueta c = new();
            return c.EliminarEtiqueta(request);
        }
    }
}
