
namespace GerenciadorTurmas.Domain.Entities
{
    public class AlunoTurmaEntity
    {
        public AlunoTurmaEntity(int? id, int alunoId, int turmaId)
        {
            Id = id;
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public int? Id { get; private set; }
        public int AlunoId { get; private set; }
        public int TurmaId { get; private set; }
    }
}
