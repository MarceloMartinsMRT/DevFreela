﻿using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
       private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
            // EFCORE
            //    var skills = _dbContext.Skills;
            //    //    var skillsViewModel = skills
            //    //                            .Select(s => new SkillViewModel(s.Id, s.Description))
            //    //                            .ToList();

            //    //    return skillsViewModel;
        }
    }
}