using Time.Domain;
using Time.Domain.Request;
using Time.Service.Interfaces;

namespace Time.Service
{
    public class ProjectTaskService: IProjectTaskService
    {
        private readonly Context _context;

        public ProjectTaskService(Context context)
        {
            _context = context;
        }

        public ProjectTask GetProjectTaskById(int id)
        {
            return _context.ProjectTasks.Find(id);
        }

        public IEnumerable<ProjectTask> GetAllProjectTasks()
        {
            return _context.ProjectTasks.ToList();
        }

        public int? CreateProjectTask(ProjectTaskRequest projectTaskRequest)
        {
             var projectExists = _context.Projects.Any(p => p.Id == projectTaskRequest.ProjectId);
            if (!projectExists)
            {
                throw new Exception("Project not found.");
            }

            ProjectTask projectTask = new ProjectTask{
                Name = projectTaskRequest.Name,
                FullName = projectTaskRequest.FullName,
                ProjectId = projectTaskRequest.ProjectId
            };

            _context.ProjectTasks.Add(projectTask);
            _context.SaveChanges();

            return projectTask.Id;
        }
    }
}