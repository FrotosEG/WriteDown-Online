using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WriteDownOnlineApi.Service.Requests.NoteRelation;

namespace WriteDownOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteRelationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NoteRelationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca os relacionamentos de uma nota")]
        public IActionResult FindNoteRelation([FromQuery] FindNoteRelationRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria as relações de uma nota")]
        public IActionResult CreateNoteRelation([FromBody] CreateNoteRelationRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza os relacionamentos de uma nota")]
        public IActionResult UpdateNoteRelation([FromBody] UpdateNoteRelationRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Deleta os relacionamentos de uma nota")]
        public IActionResult DeleteNoteRelation([FromBody] DeleteNoteRelationRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
