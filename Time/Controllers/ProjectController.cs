using Microsoft.AspNetCore.Mvc;
using Time.Domain;
using Time.Domain.Interfaces;
using Time.Domain.Request;

namespace Time.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectRequest project)
        {
            var projectId = _projectService.CreateProject(project);
            if (projectId == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetProjectById), new { id = projectId }, project);
        }
    }
}