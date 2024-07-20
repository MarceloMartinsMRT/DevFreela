using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDBContext _dBContext;
        public CreateCommentCommandHandler(DevFreelaDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dBContext.ProjectComments.AddAsync(comment);
            await _dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
