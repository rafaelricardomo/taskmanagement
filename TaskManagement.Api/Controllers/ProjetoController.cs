using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Dtos;
using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Validations;

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

        [ProducesResponseType(typeof(List<ProjetoDto>),StatusCodes.Status200OK)]
        [HttpGet(Name = "")]
        public async Task<IActionResult> ListarProjetos()
        {
            var projetos = await _projetoService.ListarProjetos();
            return Ok(projetos);
        }

        [ProducesResponseType(typeof(ProjetoDetalheDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProjetoDetalheDto), StatusCodes.Status404NotFound)]
        [HttpGet("{projetoId}")]
        public async Task<IActionResult> ObterProjeto([FromRoute] Guid projetoId)
        {
            var projeto = await _projetoService.ObterProjetoDetalhe(projetoId);
            if (projeto == null) 
                return NotFound(); 
            return Ok(projeto);
        }

        [ProducesResponseType(typeof(List<TarefaDto>), StatusCodes.Status200OK)]
        [HttpGet("{projetoId}/tarefa")]
        public async Task<IActionResult> ListarTarefas([FromRoute] Guid projetoId)
        {
            var tarefas = await _tarefaService.ListarTarefas(projetoId);
            return Ok(tarefas);
        }

        [ProducesResponseType(typeof(CriarProjetoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CriarProjeto([FromBody] CriarProjetoDto dto)
        {
            var (isValid, errorMessages) = dto.Validate();
            if (!isValid) return BadRequest(errorMessages);

            await _projetoService.CriarProjeto(dto);
            return Created(string.Empty, dto);
        }

        [ProducesResponseType(typeof(AlterarProjetoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [HttpPut("{projetoId}")]
        public async Task<IActionResult> AlterarProjeto([FromRoute] Guid projetoId, [FromBody] AlterarProjetoDto dto)
        {
            var (isValid, errorMessages) = dto.Validate();
            if (!isValid) return BadRequest(errorMessages);

            await _projetoService.AlterarProjeto(projetoId, dto);
            return Accepted(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{projetoId}")]
        public async Task<IActionResult> DeletarProjeto([FromRoute] Guid projetoId)
        {
            await _projetoService.RemoverProjeto(projetoId);
            return Ok();
        }

        [ProducesResponseType(typeof(CriarTarefaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [HttpPost("{projetoId}/tarefa")]
        public async Task<IActionResult> CriarTarefa([FromRoute] Guid projetoId, [FromBody] CriarTarefaDto dto)
        {
            var (isValid, errorMessages) = dto.Validate();
            if (!isValid) return BadRequest(errorMessages);

            await _tarefaService.CriarTarefa(projetoId, dto);
            return Created(string.Empty, dto);
        }

        [ProducesResponseType(typeof(AlterarTarefaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [HttpPut("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> AlterarTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] AlterarTarefaDto dto)
        {
            var (isValid, errorMessages) = dto.Validate();
            if (!isValid) return BadRequest(errorMessages);

            await _tarefaService.AlterarTarefa(projetoId, tarefaId, dto);
            return Accepted(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> RemoverTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] TarefaDto tarefaDto)
        {
            await _tarefaService.RemoverTarefa(projetoId, tarefaId);
            return Ok();
        }

        [ProducesResponseType(typeof(CriarComentarioDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [HttpPost("{projetoId}/tarefa/{tarefaId}/comentario")]
        public async Task<IActionResult> CriarComentarioTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId, [FromBody] CriarComentarioDto dto)
        {
            var (isValid, errorMessages) = dto.Validate();
            if (!isValid) return BadRequest(errorMessages);

            await _tarefaService.CriarComentarioTarefa(projetoId, tarefaId, dto);
            return Created(string.Empty, dto);
        }

        [ProducesResponseType(typeof(TarefaDetalheDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TarefaDetalheDto), StatusCodes.Status404NotFound)]
        [HttpGet("{projetoId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> ObterDetalheTarefa([FromRoute] Guid projetoId, [FromRoute] Guid tarefaId)
        {
            var tarefa = await _tarefaService.ObterTarefaDetalhe(projetoId, tarefaId);
            if (tarefa == null) 
                return NotFound();
            return Ok(tarefa);
        }
    }
}
