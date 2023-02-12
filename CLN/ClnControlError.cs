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
    public class ClnControlError
    {
        public CenControlError InsertControlError(CenControlError request)
        {
            CadControlError c = new CadControlError();
            return c.RegistrarControlError(request);
        }
    }
}
