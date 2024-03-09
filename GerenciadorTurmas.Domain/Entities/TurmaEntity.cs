namespace GerenciadorTurmas.Domain.Entities
{
    public class TurmaEntity
    {
        public TurmaEntity(int? id, string turma, int ano)
        {
            Id = id;
            Turma = turma;
            Ano = ano;
        }

        public int? Id { get; private set; }
        public string Turma { get; private set; }
        public int Ano { get; private set; }
    }
}
