namespace GerenciadorTurmas.Domain.Entities
{
    public class AlunoEntity
    {
        public AlunoEntity(int? id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int? Id { get; private set; }
        public string Nome { get; private set; }
    }
}
