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
    public class ClnMaterial
    {
        public CenControlError ListarMaterial(ListarMaterialRequest request)
        {
            CadMaterial c = new();
            return c.ListarMateriales(request);
        }
        public CenControlError IudMaterial(IUDMaterialRequest request, string accion)
        {
            CadMaterial c = new();
            return c.IUDMaterial(request, accion);
        }
        public CenControlError ObtenerMaterial(int id)
        {
            CadMaterial c = new();
            return c.ObtenerMaterial(id);
        }
    }
}
