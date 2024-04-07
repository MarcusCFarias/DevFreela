using DevFreela.Application.InputModels.Project;
using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;

        }

        public void CreateComment(CreateProjectCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.ProjectId, inputModel.UserId);

            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            
            project.Cancel();
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;

            var projects = _dbContext.Projects
                .Skip(skip)
                .Take(pageSize)
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();

            return projects;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return null;

            var projectViewModel = new ProjectDetailsViewModel(project.Title, project.Description, project.Status, project.IdClient, project.IdFreelancer);

            return projectViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}
