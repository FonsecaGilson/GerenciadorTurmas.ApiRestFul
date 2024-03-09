using AutoMapper;
using GerenciadorTurmas.Domain.Entities;

namespace GerenciadorTurmas.Api.Models.Aluno
{
    public class AlunoMapProfile : Profile
    {
        public AlunoMapProfile()
        {
            CreateMap<AlunoInput, AlunoEntity>().ReverseMap();
        }
    }
}
