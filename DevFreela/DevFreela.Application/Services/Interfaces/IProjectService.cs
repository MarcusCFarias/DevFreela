using DevFreela.Application.InputModels.Project;
using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(int pageNumber, int pageSize);
        ProjectDetailsViewModel GetById(int id);
        int Create(NewProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
        void CreateComment(CreateProjectCommentInputModel inputModel); 
    }
}
