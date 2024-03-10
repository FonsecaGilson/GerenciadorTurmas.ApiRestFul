namespace BancoDadosTest.Domain.Entities
{
    public class AlunoEntity
    {
        public AlunoEntity(int? id, string nome, string usuario, string senha)
        {
            Id = id;
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
        }

        public int? Id { get; private set; }
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
    }
}
