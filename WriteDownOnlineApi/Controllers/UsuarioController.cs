using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.Usuario;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("criar-usuario")]
        [SwaggerOperation(Summary = "Cria Usuário.")]
        public IActionResult GerarAdesao([FromBody]CriarUsuarioRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}