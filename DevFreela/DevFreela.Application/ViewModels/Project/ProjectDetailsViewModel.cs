using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(string title, string description, ProjectStatusEnum status, int idClient, int idFreelancer)
        {
            Title = title;
            Description = description;
            Status = status;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
    }
}
