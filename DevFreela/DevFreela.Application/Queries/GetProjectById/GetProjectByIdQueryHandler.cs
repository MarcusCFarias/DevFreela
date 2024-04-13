using DevFreela.Application.ViewModels;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistance;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Title,
                project.Description,
                project.Status,
                project.IdClient,
                project.IdFreelancer
                );

            return projectDetailsViewModel;
        }
    }
}
