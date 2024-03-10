using AutoMapper;
using BancoDadosTest.Domain.Entities;
using GerenciadorTurmas.Api.Models.Turma;

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
