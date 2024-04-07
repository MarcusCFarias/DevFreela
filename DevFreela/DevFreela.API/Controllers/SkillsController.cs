using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }
    }
}
