using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Controllers;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.UoW.Api.v3.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/voos")]
    public class VooController : MainController
    {
        private readonly IVooRepository _vooRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public VooController(IVooRepository vooRepository,
                             IPessoaRepository pessoaRepository,
                             IMapper mapper)
        {
            _vooRepository = vooRepository;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
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
            voo.Disponibilidade = 4;

            await _pessoaRepository.ExcluirPessoasDoVoo(id);
            await _vooRepository.UpdateVoo(_mapper.Map<Voo>(voo));
            transacao = await _vooRepository.Commit();
            return Ok(voo);

        }

        [HttpPost("criar-voo-dto")]
        [ProducesResponseType(typeof(Voo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarVoo(VooDTO vooDto)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo Inválido");

            vooDto.Id = Guid.Parse("C05ACEB7-1667-4D8F-BD9E-400984609721"); 

            try
            {
                await _vooRepository.CriarVoo(_mapper.Map<Voo>(vooDto));
                var transacao = await _vooRepository.Commit();
                return CreatedAtAction(nameof(CriarVoo), vooDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
