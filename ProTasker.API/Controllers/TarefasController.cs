using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Services;

namespace ProTasker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private TarefasService tarefasService;

        public TarefasController()
        {
            this.tarefasService = new TarefasService();
        }

        [HttpGet("{projetoId}")]
        public IActionResult Get(int projetoId) => Ok(tarefasService.GetAll(projetoId));

        [HttpPost]
        public IActionResult Post(PostTarefaDTO newTarefa) => Ok(tarefasService.Create(newTarefa));

        [HttpPut]
        public IActionResult Put(PutTarefaDTO putTarefa) => Ok(tarefasService.Put(putTarefa, int.Parse(User.FindFirst("idUsuario")?.Value)));
        
        [HttpPut("Copentario")]
        public IActionResult Put(PutComentarioDTO putTarefa) => Ok(tarefasService.Put(putTarefa, int.Parse(User.FindFirst("idUsuario")?.Value)));


        [HttpDelete("{tarefaId}")]
        public IActionResult Delete(int tarefaId)
        {
            tarefasService.Delete(tarefaId);
            return Ok("Tarefa removida com sucesso!");
        }
    }
}
