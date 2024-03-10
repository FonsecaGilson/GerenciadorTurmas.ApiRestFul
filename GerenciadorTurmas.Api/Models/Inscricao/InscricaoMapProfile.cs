using AutoMapper;
using BancoDadosTest.Domain.Entities;

namespace BancoDadosTest.Api.Models.Inscricao
{
    public class InscricaoMapProfile : Profile
    {
        public InscricaoMapProfile()
        {
            CreateMap<InscricaoInput, AlunoTurmaEntity>().ReverseMap();
        }
    }
}
