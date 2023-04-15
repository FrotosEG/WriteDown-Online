namespace WriteDownOnlineApi.Domain.Interface.Core
{
    public interface IDapperUtil
    {
        List<T> RunQuery<T>(string query, int tempoConexao = 60, object parametros = null);
    }
}
