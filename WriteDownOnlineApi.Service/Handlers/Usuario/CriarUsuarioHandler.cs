using MediatR;
using WriteDownOnlineApi.Domain.Entities.Core;
using WriteDownOnlineApi.Service.Requests.Usuario;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Usuario
{
    public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioRequest, BaseResponse>
    {
        public CriarUsuarioHandler()
        {
        }

        public Task<BaseResponse> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var retorno = new BaseResponse()
            {
                MensagemSucesso = "Deu bom",
                StatusCode = 200,
                Sucesso = true,
            };
            return Task.FromResult(retorno);
        }
    }
}
