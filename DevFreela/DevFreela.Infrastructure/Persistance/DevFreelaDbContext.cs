using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistance
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>()
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha descrição de Projeto 2", 1, 1, 5000)
            };

            Users = new List<User>()
            {
                new User("admin", "admin", DateTime.Now),
                new User("user", "user", DateTime.Now)
            };

            Skills = new List<Skill>()
            {
                new Skill(".NET Core"),
                new Skill("Angular"),
                new Skill("React")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}

