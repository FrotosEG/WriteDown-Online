using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Infra.Repositories.Core
{
    public class DapperUtil : IDapperUtil
    {
        private readonly IConfiguration _configuration;

        public DapperUtil(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Possível não funcionamento por causa do pacote da microsoft (talvez seja só pra sql server e não para postgres)!
        public List<T> RunQuery<T>(string query, int tempoConexao = 60, object parametros = null)
        {
            using SqlConnection conexao = new SqlConnection(_configuration.GetConnectionString("Itlsys"));
            return conexao.Query<T>(query, parametros, null, true, tempoConexao).ToList();
        }
    }
}
