using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.User;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca usuário")]
        public IActionResult FindUser([FromQuery] FindUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpGet, Route("Login")]
        [SwaggerOperation(Summary = "Loga usuário")]
        public IActionResult LoginUser([FromQuery] LoginUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria usuário.")]
        public IActionResult CreateUser([FromBody]CreateUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update usuário.")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Deleta usuário.")]
        public IActionResult DeleteUser([FromBody] DeleteUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}