using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels.Skill
{
    public class SkillViewModel
    {
        public SkillViewModel(string description)
        {
            Description = description;
        }
        public string Description { get; private set; }
    }
}
