using DevFreela.Application.ViewModels;
using DevFreela.Application.ViewModels.Project;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery()
        {
        }
    }
}
