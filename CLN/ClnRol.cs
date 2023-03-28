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
    public class ClnRol
    {
        public CenControlError ListarRolesDeUsuario(ListarRolDeUsuarioRequest request)
        {
            CadRol c = new();
            return c.ListarRolDeUsuario(request);
        }
    }
}
