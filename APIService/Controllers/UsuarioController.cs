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
                var token = new JwtSecurityToken();
                if (request.codigo == "1") 
                {
                    var jwt = _configuration.GetSection("jwt").Get<CenJWT>();
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("user", JsonConvert.SerializeObject(request.objeto))
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    token = new JwtSecurityToken
                        (
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMilliseconds(jwt.Expire*1000),
                            signingCredentials: singIn
                        );
                    var tokennuevo = new JwtSecurityTokenHandler().WriteToken(token);
                    ((UsuarioResponse)request.objeto).Token = tokennuevo;
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
