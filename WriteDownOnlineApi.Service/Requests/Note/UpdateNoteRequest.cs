﻿using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class UpdateNoteRequest : IRequest<IOperationResultBase>
    {
        public long NoteId { get; set; }
        public long IdVault { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public long UpdatedBy { get; set; }
    }
}
