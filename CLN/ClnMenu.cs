using CAD;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnMenu
    {
        public CenControlError ListarMenuCategoria()
        {
            CadMenu c = new();
            return c.ListarMenuCategoria();
        }
        public CenControlError ListarMenuMaterial()
        {
            CadMenu c = new();
            return c.ListarMenuMaterial();
        }
        public CenControlError ListarMenuEtiquetas()
        {
            CadMenu c = new();
            return c.ListarMenuEtiquetas();
        }
    }
}
