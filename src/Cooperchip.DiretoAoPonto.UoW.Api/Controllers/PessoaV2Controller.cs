using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.Repositories.Abstraction;
using Cooperchip.DiretoAoPonto.Data.Repositories.V2.Abstrations;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/pessoa-v2")]
    public class PessoaV2Controller : Controller
    {
        private readonly IUnitOfW _unitoW;
        private readonly IPessoaRepository _repoPessoa;
        private readonly IVooRepository _repoVoo;
        private readonly IMapper _mapper;

        public PessoaV2Controller(IPessoaRepository repoPessoa,
                                  IVooRepository repoVoo,
                                  IMapper mapper, 
                                  IUnitOfW unitoW)
        {
            _repoPessoa = repoPessoa;
            _repoVoo = repoVoo;
            _mapper = mapper;
            _unitoW = unitoW;
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
        public async Task<IActionResult> AdicionarPassageiro(PessoaRequest pessoa)
        {
            if (!ModelState.IsValid) return BadRequest("O modelo está inválido!");

            var pessoaModel = new Pessoa
            {
                VooId = pessoa.VooId,
                Nome = pessoa.Nome
            };

            try
            {
                await _repoPessoa.AdicionarSeAoVoo(pessoaModel);
                await _repoVoo.DecrementarVaga(pessoa.VooId);

                var transacao = await _unitoW.Commit();

                //return Ok(pessoaDto); ===>>> Aqui estamos deixando de cumprir o padrão RESTFul
                return CreatedAtAction(nameof(AdicionarPassageiro), _mapper.Map<PessoaDTO>(pessoaModel));

            }
            catch (Exception ex)
            {
                await _unitoW.Rollback();
                return BadRequest(ex.Message);
            }
        }

    }
}
