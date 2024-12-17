using Microsoft.AspNetCore.Mvc;
using ProTasker.API.Services;

namespace ProTasker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        public TarefasController()
        {
           // this.tarefasService = new TarefasService();
        }
        [HttpGet("{projetoId}")]
        public IActionResult Get(int projetoId) => Ok(new TarefasService().GetAll(projetoId));

    }
}
