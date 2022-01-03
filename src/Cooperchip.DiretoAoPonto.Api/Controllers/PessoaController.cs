using Cooperchip.DiretoAoPonto.Domain.Entities;
using Cooperchip.DiretoAoPonto.Uow.Models;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkExample.Data.Repositories;

namespace Cooperchip.DiretoAoPonto.Uow.Controllers
{
    [ApiController]
    //[Route("[Controller]")]
    [Route("api/pessoa")]
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

        /// <summary>
        /// Deixando o erro estourar na tela.
        /// E é gerado um StatusCode 500, o que é um erro.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPost("adicionar-pessoa")]
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

        /// <summary>
        /// A partir do Asp.Net Core 2.1 não precisamos mais
        /// informar como receberemos os dados, quando for
        /// um [FromBody], mas não há problema em passar
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        /// <remarks>Esperamos receber um 201 - Creaed - ou um 400 - BadRequest</remarks>
        [HttpPost("add-pessoa")]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PessoaDTO>> AddPessoa(PessoaRequest pessoa)
        {
            var pessoaModel = new Pessoa
            {
                VooId = pessoa.VooId,
                Nome = pessoa.Nome
            };

            try
            {
                await _pessoaRepo.AdicionarPessoa(pessoaModel);
                await _vooRepo.DecrementarPessoa(pessoa.VooId);
                await _pessoaRepo.Commit();
                var pessoaDto = new PessoaDTO
                {
                    VooId = pessoaModel.VooId,
                    Nome = pessoaModel.Nome,
                    Id = pessoaModel.Id
                };
                return Ok(pessoaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
