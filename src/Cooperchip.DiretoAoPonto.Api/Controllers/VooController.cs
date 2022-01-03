using Cooperchip.DiretoAoPonto.Api.Configurations.AppSettings;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cooperchip.DiretoAoPonto.Api.Controllers
{
    [ApiController]
    [Route("api/voo")]
    public class VooController : Controller
    {
        private readonly IVooRepository _vooRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly VooSettings _settings;

        public VooController(IVooRepository vooRepository,
                             IPessoaRepository pessoaRepository, 
                             IOptions<VooSettings> settings)
        {
            _vooRepository = vooRepository;
            _pessoaRepository = pessoaRepository;
            _settings = settings.Value;
        }

        [HttpGet("listar-voos")]
        public async Task<IEnumerable<Voo>> ListarTodos()
        {
            return await _vooRepository.SelecionarTodos();
        }

        [HttpGet("resetar-voo")]
        public async Task<IActionResult> ResetarVoo(Guid? id)
        {
            if (id == null) id = Guid.Parse("C05ACEB7-1667-4D8F-BD9E-400984609721");

            var voo = await _vooRepository.SelecionarPorId(id.Value);

            if (voo == null) return NotFound("Voo não encontrado ou nulo!");

            voo.Id = id.Value;
            voo.Disponibilidade = 4;

            await _pessoaRepository.ExcluirPessoasDoVoo(id.Value);
            await _vooRepository.UpdateVoo(voo);
            await _vooRepository.Commit();

            return NoContent();
        }

        [HttpPost("criar-voo")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Voo>> CriarVoo()
        {
            var voo = new Voo()
            {
                Id = _settings.Id,
                Codigo = _settings.Codigo,
                Nota = _settings.Nota,
                Capacidade = _settings.Capacidade,
                Disponibilidade = _settings.Disponibilidade,
                Pessoas = new List<Pessoa>()
            };

            try
            {
                await _vooRepository.CriarVoo(voo);
                await _vooRepository.Commit();
                return CreatedAtAction(nameof(CriarVoo), voo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
