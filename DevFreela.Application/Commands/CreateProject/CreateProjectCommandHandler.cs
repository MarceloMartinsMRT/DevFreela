using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {

        private readonly DevFreelaDBContext _dbContext;
        public CreateProjectCommandHandler(DevFreelaDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title,
                                      request.Description,
                                      request.IdClient,
                                      request.IdFreelancer,
                                      request.TotalCost);

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
