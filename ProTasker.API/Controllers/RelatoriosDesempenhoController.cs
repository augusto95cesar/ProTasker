using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using ProTasker.API.Models.Enum;
using ProTasker.API.Services;
using System.Security.Claims;

namespace ProTasker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosDesempenhoController : ControllerBase
    {
        [HttpGet("Desempenho")]
        public IActionResult Desempenho()
        {
            if (TipoUsuario.Admin != (TipoUsuario)(int.Parse(User.FindFirst(ClaimTypes.Role)?.Value)))
                 throw new Exception("Perfil não é Admin");

            return Ok(new RelatoriosDesempenhoService().GetRdlDesempenho());
        }
    }
}
