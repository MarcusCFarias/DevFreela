using DevFreela.Application.ViewModels;
using DevFreela.Application.ViewModels.Skill;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
