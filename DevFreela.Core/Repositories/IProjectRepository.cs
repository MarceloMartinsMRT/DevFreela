﻿using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task SaveChangesAsync(); 
        Task AddCommentAsync(ProjectComment projectComment);
    }
}
