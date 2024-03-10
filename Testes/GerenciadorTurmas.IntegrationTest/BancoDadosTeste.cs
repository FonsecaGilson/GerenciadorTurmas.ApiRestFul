using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace GerenciadorTurmas.IntegrationTest
{
    public class BancoDadosTeste
    {
        private readonly IConfiguration _configuration;

        public BancoDadosTeste(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ExecutarScript(string diretorioScript)
        {
            string[] arrayArquivosSql = Directory.GetFiles(diretorioScript);

            foreach (string arquivosSql in arrayArquivosSql)
            {
                string script = File.ReadAllText(arquivosSql);

                string connectionString = _configuration.GetConnectionString("SqlServer");

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(script, connection);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
