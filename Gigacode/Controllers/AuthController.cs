using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Gigacode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost(Name = "Token")]
        public ActionResult CreateJwtToken([FromBody] string myKey)
        {
            try
            {
                var key = _configuration.GetValue<string>("ApiKey");
                var keyEncoding = Encoding.ASCII.GetBytes(key);

                var descriptor = new SecurityTokenDescriptor
                {
                    Issuer = "Gigacode",
                    Audience = "gigacode.com.br",
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncoding), SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                
                var tokenEncoding = tokenHandler.CreateToken(descriptor);

                var token = tokenHandler.WriteToken(tokenEncoding);

                return Ok(new
                {
                    StatusCode = 200,
                    Token = token.ToString()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}