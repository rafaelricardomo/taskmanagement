using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Dtos;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;
        private readonly IProjetoService _projetoService;
        private readonly ITarefaService _tarefaService;
        public ProjetoController(
            ILogger<ProjetoController> logger, 
            IProjetoService projetoService, 
            ITarefaService tarefaService
            )
        {
            _logger = logger;
            _projetoService = projetoService;
            _tarefaService = tarefaService;
        }

        [HttpGet(Name = "")]
        public async Task<IActionResult> ListarProjetos()
        {
            var projetos = await _projetoService.ListarProjetos();
            return Ok(projetos);
        }

        [HttpGet("{projetoId}")]
        public async Task<IActionResult> ObterProjeto([FromRoute] Guid projetoId)
        {
            var projeto = await _projetoService.ObterProjetoDetalhe(projetoId);
            return Ok(projeto);
        }

        [HttpGet("{projetoId}/tarefa")]
        public async Task<IActionResult> ListarTarefas([FromRoute] Guid projetoId)
        {
            var tarefas = await _tarefaService.ListarTarefas(projetoId);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto([FromBody] ProjetoDto projetoDto)
        {
            await _projetoService.CriarProjeto(projetoDto);
            return Created(string.Empty, projetoDto);
        }

        [HttpPut("{projetoId}")]
        public async Task<IActionResult> AlterarProjeto([FromRoute] Guid projetoId, [FromBody] ProjetoDto projetoDto)
        {
            await _projetoService.AlterarProjeto(projetoId, projetoDto);
            return Accepted(projetoDto);
        }

        [HttpDelete("{projetoId}")]
        public async Task<IActionResult> DeletarProjeto([FromRoute] Guid projetoId)
        {
            await _projetoService.RemoverProjeto(projetoId);
            return Ok();
        }

        [HttpPost("{projetoId}/tarefa")]
        public async Task<IActionResult> CriarTarefa([FromRoute] Guid projetoId, [FromBody] TarefaDto tarefaDto)
        {
            await _tarefaService.CriarTarefa(projetoId, tarefaDto);
            return Created(string.Empty, tarefaDto);
        }

        [HttpPut("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> AlterarTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] TarefaDto tarefaDto)
        {
            await _tarefaService.AlterarTarefa(projetoId, tarefaId, tarefaDto);
            return Accepted(tarefaDto);
        }

        [HttpDelete("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> RemoverTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] TarefaDto tarefaDto)
        {
            await _tarefaService.RemoverTarefa(projetoId, tarefaId);
            return Ok();
        }

        [HttpPost("{projetoId}/tarefa/{tarefaId}/comentario")]
        public async Task<IActionResult> CriarComentarioTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] ComentarioDto comentarioDto)
        {
            await _tarefaService.CriarComentarioTarefa(projetoId, tarefaId, comentarioDto);
            return Created(string.Empty, comentarioDto);
        }

        [HttpGet("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> ObterDetalheTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId)
        {
            var tarefa = await _tarefaService.ObterTarefaDetalhe(projetoId, tarefaId);
            return Ok(tarefa);
        }
    }
}
