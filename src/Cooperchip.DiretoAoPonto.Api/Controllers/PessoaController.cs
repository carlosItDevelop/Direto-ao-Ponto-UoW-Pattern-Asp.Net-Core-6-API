using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstractions;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Cooperchip.DiretoAoPonto.Uow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.Uow.Controllers
{
    [ApiController]
    //[Route("[Controller]")]
    [Route("api/pessoa")]
    public class PessoaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepo;
        private readonly IVooRepository _vooRepo;

        public PessoaController(IPessoaRepository pessoaRepo,
                                IVooRepository vooRepo, 
                                IMapper mapper)
        {
            _pessoaRepo = pessoaRepo;
            _vooRepo = vooRepo;
            _mapper = mapper;
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
                await _pessoaRepo.Commit();

                //return Ok(pessoaDto); ===>>> Aqui estamos deixando de cumprir o padrão RESTFul
                return CreatedAtAction(nameof(AdicionarPassageiro), _mapper.Map<PessoaDTO>(pessoaModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
