using Cooperchip.DiretoAoPonto.Domain.Entities;
using Cooperchip.DiretoAoPonto.Uow.Models;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkExample.Data.Repositories;

namespace Cooperchip.DiretoAoPonto.Uow.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : Controller
    {

        private readonly IPessoaRepository _pessoaRepo;
        private readonly IVooRepository _vooRepo;

        public PessoaController(IPessoaRepository pessoaRepo,
                                IVooRepository vooRepo)
        {
            _pessoaRepo = pessoaRepo;
            _vooRepo = vooRepo;
        }

        [HttpPost]
        public async Task<PessoaDTO> AdicionarPessoa([FromBody] PessoaRequest pessoa)
        {
            var pessoaModel = new Pessoa
            {
                VooId = pessoa.VooId,
                Nome = pessoa.Nome
            };

            await _pessoaRepo.AdicionarPessoa(pessoaModel);
            await _vooRepo.DecrementarPessoa(pessoa.VooId);

            await _pessoaRepo.Commit();

            var pessoaDto = new PessoaDTO
            {
                VooId = pessoaModel.VooId,
                Nome = pessoaModel.Nome,
                Id = pessoaModel.Id
            };
            return pessoaDto;


        }
    }
}
