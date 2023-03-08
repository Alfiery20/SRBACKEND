using CAD;
using CEN;
using CEN.Request;
using CEN.Response;
using CLN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        { 
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] IUDUsuario iUDUsuario)
        {
            try
            {
                ClnUsuario clnUsuario = new ClnUsuario();
                var request = clnUsuario.IudUsuario(iUDUsuario, "I");
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    tipo = "C",
                    descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
        [HttpPost("validarUser")]
        public IActionResult ValidarUsuario([FromBody] LoginRequest loginRequest)
        {
            try
            {
                ClnUsuario clnUsuario = new ClnUsuario();
                var request = clnUsuario.ValidarUsuario(loginRequest);
                if (request.codigo == "1") 
                {
                    var jwt = _configuration.GetSection("jwt").Get<CenJWT>();
                    JwtSecurityToken token = TokenService.GenerarToken(jwt, (UsuarioResponse)request.objeto);
                    var tokennuevo = new JwtSecurityTokenHandler().WriteToken(token);
                    ((UsuarioResponse)request.objeto).Token = tokennuevo;
                    InsertTokenRequest insert = new InsertTokenRequest();
                    insert.Correo = ((UsuarioResponse)request.objeto).CorreoElectronico;
                    insert.Token = ((UsuarioResponse)request.objeto).Token;
                    clnUsuario.InsertToken(insert);
                }
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    tipo = "C",
                    descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
    }
}
