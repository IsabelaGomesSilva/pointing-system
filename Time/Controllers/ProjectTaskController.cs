using Microsoft.AspNetCore.Mvc;
using Time.Domain;
using Time.Domain.Request;
using Time.Service.Interfaces;

namespace Time.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectTaskById(int id)
        {
            var projectTask = _projectTaskService.GetProjectTaskById(id);
            if (projectTask == null)
            {
                return NotFound();
            }
            return Ok(projectTask);
        }

        [HttpGet]
        public IActionResult GetAllProjectTasks()
        {
            var projectTasks = _projectTaskService.GetAllProjectTasks();
            return Ok(projectTasks);
        }

        [HttpPost]
        public IActionResult CreateProjectTask([FromBody] ProjectTaskRequest projectTask)
        {
            var projectTaskId =_projectTaskService.CreateProjectTask(projectTask);
            if (projectTaskId == null)
                return BadRequest();
            return CreatedAtAction(nameof(GetProjectTaskById), new { id = projectTaskId }, projectTask);
        }

    }
}