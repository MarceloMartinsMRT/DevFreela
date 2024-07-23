using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDTO>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDTO> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            var projectDTO = new ProjectDTO(
                                        project.Id,
                                        project.Title,
                                        project.Description,
                                        project.TotalCost,
                                        project.StartedAt,
                                        project.FinishedAt,
                                        project.Client.FullName,
                                        project.Freelancer.FullName);

            return projectDTO;
        }
    }
}
