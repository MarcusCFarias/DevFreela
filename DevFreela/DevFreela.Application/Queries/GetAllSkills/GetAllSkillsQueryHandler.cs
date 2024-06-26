﻿
using DevFreela.Application.Repositories;
using DevFreela.Application.ViewModels.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
