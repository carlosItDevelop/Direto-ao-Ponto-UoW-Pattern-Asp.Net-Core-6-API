﻿using AutoMapper;
using Cooperchip.DiretoAoPonto.Data.FailedRepository;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/pessoafailed")]
    public class PessoaFailedController : Controller
    {

        private readonly IPessoaFailedRepository _repoPessoa;
        private readonly IVooFailedRepository _repoVoo;
        private readonly IMapper _mapper;

        public PessoaFailedController(IPessoaFailedRepository repoPessoa,
                                      IVooFailedRepository repoVoo, 
                                      IMapper mapper)
        {
            _repoPessoa = repoPessoa;
            _repoVoo = repoVoo;
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
        public async Task<IActionResult> AdicionarPassageiro(PessoaRequest pessoa)
        {
            if(!ModelState.IsValid) return BadRequest("O modelo está inválido!");

            var pessoaModel = new Pessoa
            {
                Nome = pessoa.Nome,
                VooId = pessoa.VooId
            };

            try
            {
                await _repoPessoa.AdicionarSeAoVoo(pessoaModel);
                await _repoVoo.DecrementarVaga(pessoa.VooId);

                return CreatedAtAction(nameof(AdicionarPassageiro), _mapper.Map<PessoaDTO>(pessoaModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
