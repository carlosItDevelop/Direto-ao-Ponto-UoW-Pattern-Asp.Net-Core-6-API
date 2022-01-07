using AutoMapper;
using Cooperchip.DiretoAoPonto.Api.Models;
using Cooperchip.DiretoAoPonto.Domain.Entities;
using Cooperchip.DiretoAoPonto.Uow.Models;

namespace Cooperchip.DiretoAoPonto.Api.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Voo, VooDTO>().ReverseMap();
        }
    }
}
