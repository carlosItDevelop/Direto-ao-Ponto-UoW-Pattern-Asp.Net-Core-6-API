using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Settings;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/voo")]
    public class VooController : ControllerBase
    {
        private readonly VooSettings _settings;
        private readonly IVooRepository _vooRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public VooController(IVooRepository vooRepository,
                             IPessoaRepository pessoaRepository,
                             IMapper mapper, 
                             IOptions<VooSettings> settings)
        {
            _vooRepository = vooRepository;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _settings = settings.Value;
        }

        [HttpGet("listar-voos")]
        public async Task<IEnumerable<Voo>> ObterTodos()
        {
            return await _vooRepository.SelecionarTodos();
        }

        [HttpGet("resetar-voo")]
        [ProducesResponseType(typeof(VooDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ResetarVoo(Guid id)
        {
            id = Guid.Parse("C05ACEB7-1667-4D8F-BD9E-400984609721");
            var transacao = false;
            var voo = await _vooRepository.SelecionarPorId(id); 
            if (voo == null)
            {
                var vooDTO = new VooDTO
                {
                    Id = id,
                    Capacidade = 4,
                    Disponibilidade = 4,
                    Codigo = "101 - Rio/Miami",
                    Nota = "Saida as 10:34h. - Horáio de Brasilia"
                };

                await _vooRepository.CriarVoo(_mapper.Map<Voo>(vooDTO));
                transacao = await _vooRepository.Commit();
                return CreatedAtAction(nameof(ResetarVoo), vooDTO);
            }

            voo.Id = id;
            voo.Capacidade = 4;
            voo.Disponibilidade= 4;

            await _pessoaRepository.ExcluirPessoasDoVoo(id);
            await _vooRepository.UpdateVoo(_mapper.Map<Voo>(voo));
            transacao = await _vooRepository.Commit();
            return Ok(voo);

        }

        [HttpPost("criar-voo-dto")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVooDTO(VooDTO vooDto)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo DTO Inválido");

            vooDto.Id = _settings.Id;

            try
            {
                await _vooRepository.CriarVoo(_mapper.Map<Voo>(vooDto));
                var transacao = await _vooRepository.Commit();
                return CreatedAtAction(nameof(CriarVooDTO), vooDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("criar-voo-appsettings")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVooAppSettings()
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
                var transacao = await _vooRepository.Commit();

                return CreatedAtAction(nameof(CriarVooAppSettings), voo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
