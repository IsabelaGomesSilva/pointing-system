using Time.Domain;
using Time.Domain.Request;

namespace Time.Service.Interfaces
{
    public interface IProjectTaskService
    {
        ProjectTask GetProjectTaskById(int id);
        IEnumerable<ProjectTask> GetAllProjectTasks();
        int? CreateProjectTask(ProjectTaskRequest projectTask);
    }
}