using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Service;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {

        private readonly ILogger<TarefaController> _logger;

        private ITarefaService _tarefaService;

        public TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(_tarefaService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _tarefaService.FindById(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest(new { Erro = "Os dados da tarefa não foram fornecidos" });

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            return Ok(_tarefaService.Create(tarefa));
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest(new { Erro = "Os dados da tarefa não foram fornecidos" });

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            var tarefaBanco = _tarefaService.FindById(id);

            if (tarefaBanco == null)
                return NotFound();

            return Ok(_tarefaService.Update(tarefa));
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _tarefaService.FindById(id);

            if (tarefaBanco == null) return NotFound();

            _tarefaService.Delete(id);
            return NoContent();
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _tarefaService.FindByTitle(titulo);

            if (tarefas == null) return NotFound();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefas = _tarefaService.FindByDate(data);

            if (tarefas.Count == 0)
                return NotFound();

            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _tarefaService.FindByStatus(status);

            if (tarefas.Count == 0)
                return NotFound();

            return Ok(tarefas);
        }
    }
}
