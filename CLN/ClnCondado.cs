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
    public class ClnCondado
    {
        public CenControlError ListarCondado(ListarCondadoRequest request)
        {
            CadCondado c = new();
            return c.ListarCondado(request);
        }
    }
}
