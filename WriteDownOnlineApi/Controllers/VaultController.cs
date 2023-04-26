using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Requests.Vault;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VaultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca vault")]
        public IActionResult FindVault([FromQuery] FindVaultRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria vault")]
        public IActionResult CreateVault([FromBody] CreateVaultRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update vault")]
        public IActionResult UpdateVault([FromBody] UpdateVaultRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Deleta vault")]
        public IActionResult DeleteVault([FromBody] DeleteVaultRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
