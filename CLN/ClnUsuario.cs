using CAD;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Encrypt;
using CEN.Helpers;

namespace CLN
{
    public class ClnUsuario
    {
        public CenControlError IudUsuario(IUDUsuario request, string accion)
        {
            CadUsuario c = new CadUsuario();
            request.clave = request.clave == null ? null : request.clave.Trim();
            request.clave = EncrypAES.EncryptStringAES(request.clave, Constants.clave_encriptacion);
            return c.IUDUsuario(request, accion);
        }
        public CenControlError ValidarUsuario(LoginRequest request)
        {
            CadUsuario c = new CadUsuario();
            request.clave = request.clave == null ? null : request.clave.Trim();
            request.clave = EncrypAES.EncryptStringAES(request.clave, Constants.clave_encriptacion);
            return c.ValidadUsuario(request);
        }
        public CenControlError InsertToken(InsertTokenRequest request)
        {
            CadUsuario c = new CadUsuario();
            return c.InsertToken(request);
        }
    }
}
