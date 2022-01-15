using AutoMapper;
using Cooperchip.DiretoAoPonto.Uow.Domain;
using Cooperchip.DiretoAoPonto.UoW.Api.Models;

namespace Cooperchip.DiretoAoPonto.UoW.Api.Mapper
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
