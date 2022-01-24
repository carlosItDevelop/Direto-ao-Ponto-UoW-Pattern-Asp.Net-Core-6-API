using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Settings;
using Cooperchip.DiretoAoPonto.UoW.Api.Controllers;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cooperchip.DiretoAoPonto.UoW.Api.v2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/voos")]
    public class VooController : MainController
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
