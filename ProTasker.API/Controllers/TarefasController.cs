﻿using Microsoft.AspNetCore.Mvc; 
using ProTasker.API.DTOs.Tarefas;
using ProTasker.API.Services;

namespace ProTasker.API.Controllers
{
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
    }
}
