using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiGP.Models;
using WebApiGP.Services.Interface;

namespace WebApiGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IUser usera;

        public AutenticacionController(IConfiguration config, IUser usera)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            this.usera = usera;
        }

        [HttpPost("Validar")]
        public IActionResult Validar(string usern, string pass) {

            var confir = usera.GetUserAdmin(usern,pass);

            if (confir != null) { 
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, confir.Username));

                if(confir.PermissionsId == 1)
                {
                    claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }else if(confir.PermissionsId == 2)
                {
                    claims.AddClaim(new Claim(ClaimTypes.Role, "Comprador"));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
