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
    public class ClnEstado
    {
        public CenControlError ListarEstados(ListarEstadoRequest request)
        {
            CadEstado c = new();
            return c.ListarEstado(request);
        }
    }
}
