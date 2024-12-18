using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTasker.API.DTOs.Projetos;
using ProTasker.API.Services;

namespace ProTasker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjetosController : ControllerBase
    {
        private ProjetoService projetoService;

        public ProjetosController()
        {
            this.projetoService = new ProjetoService();
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        { 
            return Ok(projetoService.GetAll(userId));
        }

        [HttpPost]
        public IActionResult Post(PostProjetoDTO newProjeto) => Ok(projetoService.Create(newProjeto));


        [HttpDelete("{projetoId}")]
        public IActionResult Delete(int projetoId)
        {
            projetoService.Delete(projetoId);
            return Ok("Projeto removido com sucesso!");
        }
    }
}
