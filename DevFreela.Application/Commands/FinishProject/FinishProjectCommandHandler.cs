using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDBContext _dbContext;
        public FinishProjectCommandHandler(DevFreelaDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Finish();
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
