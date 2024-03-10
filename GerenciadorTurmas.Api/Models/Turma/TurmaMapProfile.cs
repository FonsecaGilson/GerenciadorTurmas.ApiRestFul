using AutoMapper;
using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Api.Models.Turma
{
    public class TurmaMapProfile : Profile
    {
        public TurmaMapProfile()
        {
            CreateMap<TurmaInput, TurmaEntity>().ReverseMap();
        }
    }
}
