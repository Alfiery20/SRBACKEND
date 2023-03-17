using CAD;
using CEN;
using CEN.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnCategoria
    {
        public CenControlError ListarCategoria(ListarCategoriaRequest request)
        {
            CadCategoria c = new CadCategoria();
            return c.ListarCategoria(request);
        }
        public CenControlError IudCategoria(IUDCategoriaRequest request, string accion)
        {
            CadCategoria c = new CadCategoria();
            return c.IUDCategoria(request, accion);
        }
        public CenControlError ObtenerCategoria(int id)
        {
            CadCategoria c = new();
            return c.ObtenerCategoria(id);
        }
    }
}
