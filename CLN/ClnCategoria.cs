using CAD;
using CEN;
using CEN.Categoria;
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
            CadCategoria c = new();
            return c.ListarCategoria(request);
        }
        public CenControlError AgregarCategoria(CenAgregarCategoria request)
        {
            CadCategoria c = new();
            return c.AgregarCategoria(request);
        }
        public CenControlError EditarCategoria(CenEditarCategoria request)
        {
            CadCategoria c = new();
            return c.EditarCategoria(request);
        }
        public CenControlError EliminarCategoria(CenEliminarCategoria request)
        {
            CadCategoria c = new();
            return c.EliminarCategoria(request);
        }
        public CenControlError ObtenerCategoria(int id)
        {
            CadCategoria c = new();
            return c.ObtenerCategoria(id);
        }
    }
}
