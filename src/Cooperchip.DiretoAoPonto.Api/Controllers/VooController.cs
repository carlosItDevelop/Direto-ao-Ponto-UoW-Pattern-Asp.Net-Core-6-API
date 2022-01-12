using AutoMapper;
using Cooperchip.DiretoAoPonto.Api.Configurations.AppSettings;
using Cooperchip.DiretoAoPonto.Api.Models;
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
        private readonly IMapper _mapper;

        public VooController(IVooRepository vooRepository,
                             IPessoaRepository pessoaRepository,
                             IMapper mapper,
                             IOptions<VooSettings> settings)
        {
            _vooRepository = vooRepository;
            _pessoaRepository = pessoaRepository;
            _settings = settings.Value;
            _mapper = mapper;
        }

        [HttpGet("listar-voos")]
        public async Task<IEnumerable<Voo>> ListarTodos()
        {
            return await _vooRepository.SelecionarTodos();
        }

        [HttpGet("resetar-voo")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ResetarVoo(Guid id)
        {
            id = Guid.Parse("C05ACEB7-1667-4D8F-BD9E-400984609721");

            var voo = await _vooRepository.SelecionarPorId(id);
            if (voo == null)
            {
                var vooDto = new VooDTO
                {
                    Id = id,
                    Disponibilidade = 4,
                    Capacidade = 4,
                    Codigo = "101 - Rio/Miami",
                    Nota = "Saída às 10:34h. Horário de Brasília"
                };

                await _vooRepository.CriarVoo(_mapper.Map<Voo>(vooDto));
                await _vooRepository.Commit();
                return CreatedAtAction(nameof(ResetarVoo), vooDto);
            }
            
            voo.Id = id;
            voo.Capacidade = 4;
            voo.Disponibilidade = 4;

            await _pessoaRepository.ExcluirPessoasDoVoo(id);
            await _vooRepository.UpdateVoo(_mapper.Map<Voo>(voo));
            await _vooRepository.Commit();
            return Ok(voo);
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
                await _vooRepository.Commit();
                return CreatedAtAction(nameof(CriarVooAppSettings), voo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criar-voo-dto")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVooDTO(VooDTO vooDto)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo DTO Inválido!");

            vooDto.Id = _settings.Id;
            //vooDto.Pessoas = new List<Pessoa>();

            try
            {
                await _vooRepository.CriarVoo(_mapper.Map<Voo>(vooDto));
                await _vooRepository.Commit();
                return CreatedAtAction(nameof(CriarVooDTO), vooDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
