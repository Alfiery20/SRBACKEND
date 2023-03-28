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
using CEN.Usuario;

namespace CLN
{
    public class ClnUsuario
    {
        public CenControlError AgregarUsuario(CenAgregarUsuario request)
        {
            CadUsuario c = new();
            request.Clave = request.Clave == null ? null : request.Clave.Trim();
            request.Clave = EncrypAES.EncryptStringAES(request.Clave, Constants.Clave_encriptacion);
            return c.AgregarUsuario(request);
        }
        public CenControlError ValidarUsuario(LoginRequest request)
        {
            CadUsuario c = new();
            request.Clave = request.Clave == null ? null : request.Clave.Trim();
            request.Clave = EncrypAES.EncryptStringAES(request.Clave, Constants.Clave_encriptacion);
            return c.ValidadUsuario(request);
        }
        public CenControlError InsertToken(InsertTokenRequest request)
        {
            CadUsuario c = new();
            return c.InsertToken(request);
        }
    }
}
