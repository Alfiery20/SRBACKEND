using CAD;
using CEN;
using CEN.Request;
using CEN.Response;
using CEN.Usuario;
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

        [HttpPost("registroUsuario")]
        public IActionResult Register([FromBody] CenAgregarUsuario iUDUsuario)
        {
            try
            {
                ClnUsuario clnUsuario = new ClnUsuario();
                var request = clnUsuario.AgregarUsuario(iUDUsuario);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
        [HttpPost("validarUsuario")]
        public IActionResult ValidarUsuario([FromBody] LoginRequest loginRequest)
        {
            try
            {
                ClnUsuario clnUsuario = new ClnUsuario();
                var request = clnUsuario.ValidarUsuario(loginRequest);
                if (request.Codigo == "1")
                {
                    var jwt = _configuration.GetSection("jwt").Get<CenJWT>();
                    JwtSecurityToken token = TokenService.GenerarToken(jwt, (UsuarioResponse)request.Objeto);
                    var tokennuevo = new JwtSecurityTokenHandler().WriteToken(token);
                    ((UsuarioResponse)request.Objeto).Token = tokennuevo;
                    InsertTokenRequest insert = new InsertTokenRequest();
                    insert.Correo = ((UsuarioResponse)request.Objeto).CorreoElectronico;
                    insert.Token = ((UsuarioResponse)request.Objeto).Token;
                    clnUsuario.InsertToken(insert);
                }
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
    }
}
