using Microsoft.AspNetCore.Mvc;
using ProTasker.API.DTOs.Projetos;
using ProTasker.API.Services;

namespace ProTasker.API.Controllers
{
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
        public IActionResult Get(int userId) =>   Ok(projetoService.GetAll(userId)); 

        [HttpPost]
        public IActionResult Post(PostProjetoDTO newProjeto) => Ok(projetoService.Create(newProjeto));
    } 
}
