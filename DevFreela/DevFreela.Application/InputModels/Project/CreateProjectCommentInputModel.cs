using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels.Project
{
    public class CreateProjectCommentInputModel
    {
        public string Content { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
