using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
    }
}
