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
        public CenControlError listarCategoria(ListarCategoriaRequest request)
        {
            CadCategoria c = new CadCategoria();
            return c.listarCategoria(request);
        }
    }
}
