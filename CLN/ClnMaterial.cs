using CAD;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEN.Material;

namespace CLN
{
    public class ClnMaterial
    {
        public CenControlError ListarMaterial(ListarMaterialRequest request)
        {
            CadMaterial c = new();
            return c.ListarMateriales(request);
        }
        public CenControlError AgregarMaterial(CenAgregarMaterial request)
        {
            CadMaterial c = new();
            return c.AgregarMaterial(request);
        }
        public CenControlError EditarMaterial(CenEditarMaterial request)
        {
            CadMaterial c = new();
            return c.EditarMaterial(request);
        }
        public CenControlError EliminarMaterial(CenEliminarMaterial request)
        {
            CadMaterial c = new();
            return c.EliminarMaterial(request);
        }
        public CenControlError ObtenerMaterial(int id)
        {
            CadMaterial c = new();
            return c.ObtenerMaterial(id);
        }
    }
}
