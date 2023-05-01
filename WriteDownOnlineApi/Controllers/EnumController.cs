using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.Enum;
using WriteDownOnlineApi.Service.Requests.Note;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("Status")]
        [SwaggerOperation(Summary = "Busca todos os enums de status")]
        public IActionResult FindUserNotes([FromQuery] FindEnumStatusRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
