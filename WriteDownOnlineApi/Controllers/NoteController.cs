using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.Note;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca notas por IdUsuário")]
        public IActionResult FindUserNotes([FromQuery] FindUserNotesRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar nota")]
        public IActionResult CreateNote([FromBody] CreateNoteRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualizar nota")]
        public IActionResult UpdateNote([FromBody] UpdateNoteRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Atualizar nota")]
        public IActionResult DeleteNote([FromBody] DeleteNoteRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
