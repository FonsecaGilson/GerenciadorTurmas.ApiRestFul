using AutoMapper;
using BancoDadosTest.Domain.Entities;

namespace GerenciadorTurmas.Api.Models.Inscricao
{
    public class InscricaoMapProfile : Profile
    {
        public InscricaoMapProfile()
        {
            CreateMap<InscricaoInput, AlunoTurmaEntity>().ReverseMap();
        }
    }
}
