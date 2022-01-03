using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.Api.Controllers
{
    [ApiController]
    [Route("api/voo")]
    public class VooController : Controller
    {
        private readonly IVooRepository _vooRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public VooController(IVooRepository vooRepository,
                             IPessoaRepository pessoaRepository)
        {
            _vooRepository = vooRepository;
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet("listar-voos")]
        public async Task<IEnumerable<Voo>> ListarTodos()
        {
            return await _vooRepository.SelecionarTodos();
        }

        [HttpGet("resetar-voo")]
        public async Task<IActionResult> ResetarVoo(Guid? id)
        {
            if (id.Value == null)
            {
                id = Guid.Parse("C05ACEB7-1667-4D8F-BD9E-400984609721");
            }

            var voo = await _vooRepository.SelecionarPorId(id.Value);

            if (voo == null)
            {
                return NotFound("Voo não encontrado ou nulo!");
            }

            voo.Id = id.Value;
            voo.Disponibilidade = 4;

            await _pessoaRepository.ExcluirPessoasDoVoo(id.Value);
            await _vooRepository.UpdateVoo(voo);
            await _vooRepository.Commit();

            return NoContent();
        }

    }
}
