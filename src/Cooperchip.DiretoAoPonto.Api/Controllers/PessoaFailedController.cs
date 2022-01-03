using Cooperchip.DiretoAoPonto.Data.FailedRepository.Abstraction;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Cooperchip.DiretoAoPonto.Uow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.Uow.Controllers
{
    [ApiController]
    //[Route("[Controller]")]
    [Route("api/pessoa")]
    public class PessoaFailedController : Controller
    {

        private readonly IPessoaFailedRepository _pessoaRepo;
        private readonly IVooFailedRepository _vooRepo;

        public PessoaFailedController(IPessoaFailedRepository pessoaRepo,
                                IVooFailedRepository vooRepo)
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
        [HttpPost("adicionar-passageiro")]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PessoaDTO>> AdicionarPassageiro(PessoaRequest pessoa)
        {
            if (!ModelState.IsValid) return BadRequest("O modelo está inválido!");

            var pessoaModel = new Pessoa
            {
                VooId = pessoa.VooId,
                Nome = pessoa.Nome
            };

            try
            {
                await _pessoaRepo.AdicionarPessoa(pessoaModel);
                await _vooRepo.DecrementarPessoa(pessoa.VooId);
                var pessoaDto = new PessoaDTO
                {
                    VooId = pessoaModel.VooId,
                    Nome = pessoaModel.Nome,
                    Id = pessoaModel.Id
                };
                return CreatedAtAction("AdicionarPassageiro", pessoaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
