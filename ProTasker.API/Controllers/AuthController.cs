using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProTasker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            // Validação das credenciais (simulação
            var idUsuario = 1;
            request.Username = "master"; 
            request.Password = "123456";

            //if (request.Username != "master" || request.Password != "123456")
            //{
            //    return Unauthorized(new { message = "Credenciais inválidas." });
            //}

            // Acessar a chave do appsettings.json
            var key = _configuration["JwtSettings:Key"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];

            // Configurações do token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
              new Claim("idUsuario", $"{idUsuario}"),
              new Claim(ClaimTypes.Name, request.Username),
              new Claim(ClaimTypes.Role, "Admin"),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            var tokenWrite = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = "Bearer " + tokenWrite });
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
